﻿using LASI.Core;
using Microsoft.AspNet.Mvc;
using Path = System.IO.Path;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LASI.WebApp.Models.DocumentStructures;
using LASI.Interop;
using LASI.Utilities;
using JobStatusMap = System.Collections.Concurrent.ConcurrentDictionary<int, LASI.WebApp.Models.Results.WorkItemStatus>;
using NaiveTopResultSelector = LASI.Core.Analysis.Heuristics.NaiveTopResultSelector;
using UpdateEventHandler = System.EventHandler<LASI.Core.Configuration.ReportEventArgs>;
using LASI.WebApp.Persistence;
using System.Collections.Immutable;
using LASI.WebApp.Models.User;
using System.Collections.Concurrent;
using System;
using Microsoft.AspNet.Authorization;
using LASI.WebApp.Models;
using System.Security.Claims;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using LASI.WebApp.Controllers.Helpers;

namespace LASI.WebApp.Controllers
{
    [Authorize]
    [Route("[Controller]")]
    public class AnalysisController : Controller
    {
        public AnalysisController(IDocumentAccessor<UserDocument> documentStore, IWorkItemsService userWorkItemsService, IHostingEnvironment hostingEnvironment)
        {
            this.documentStore = documentStore;
            this.userWorkItemsService = userWorkItemsService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("{documentId}")]
        public async Task<DocumentModel> Get(string documentId) => await ProcessOne(documentId);


        [HttpGet]
        public async Task<IEnumerable<DocumentModel>> Get() => await LoadResultDocument(GetAllUserSources());
        private async Task<DocumentModel> ProcessOne(string documentId)
        {
            var document = documentStore.GetById(User.GetUserId(), documentId);
            if (document == null)
            {
                return await Context.WriteNotFoundResponseAsnyc<DocumentModel>(DocumentNotFoundMessage);
            }
            var model = await LoadResultDocument(new[] { document });
            return model.First();
        }

        private IEnumerable<UserDocument> GetAllUserSources() => documentStore.GetAllForUser(Context.User.GetUserId());

        private async Task<IEnumerable<DocumentModel>> LoadResultDocument(IEnumerable<UserDocument> userDocuments) =>
            from document in await ProcessUserDocuments(userDocuments)
            select new DocumentModel(
                document: document,
                chartItems: NaiveTopResultSelector.GetTopResultsByEntity(document).Take(MaxChartItems),
                documentId: userDocuments.FirstOrDefault(source => source.Name == document.Name).Id
            );
        private async Task<IEnumerable<Document>> ProcessUserDocuments(IEnumerable<UserDocument> userDocuments)
        {
            var workItems = CreateWorkItemsForProcessingOperations(userDocuments).ToList();
            workItems.ForEach(item => userWorkItemsService.UpdateWorkItemForUser(User.GetUserId(), item));
            var results = await Task.WhenAll(from source in userDocuments
                                             join workItem in workItems
                                             on source.Id equals workItem.Id
                                             select Task.Run(() => ProcessUserDocument(source, workItem)));
            ProcessedDocuments = ProcessedDocuments.Union(results);
            return results;
        }

        private async Task<Document> ProcessUserDocument(UserDocument source, WorkItem workItem)
        {
            var analyzer = new AnalysisOrchestrator(source);
            analyzer.ProgressChanged += (sender, e) =>
            {
                workItem.PercentComplete = Math.Round(Math.Min(workItem.PercentComplete + e.PercentWorkRepresented, 100), 4);
                workItem.StatusMessage = e.Message;
                workItem.State = TaskState.Ongoing;
            };
            var processedDocument = await analyzer.ProcessAsync();
            workItem.PercentComplete = 100;
            workItem.StatusMessage = "Analysis Complete.";
            workItem.State = TaskState.Complete;
            return processedDocument.First();
        }

        /// <summary>
        /// Determines the active user and appends the document processing operations to their active work items.
        /// </summary>
        /// <param name="userDocuments">The documents whose processing will become active work items.</param>
        /// <returns>A <see cref="Task"/> representing the ongoing operation.</returns>
        private IEnumerable<WorkItem> CreateWorkItemsForProcessingOperations(IEnumerable<UserDocument> userDocuments) =>
            from document in userDocuments
            let isCached = ProcessedDocuments.Any(d => d.Name.EqualsIgnoreCase(document.Name))
            let state = isCached ? TaskState.Complete : TaskState.Pending
            let statusMessage = isCached ? "Analysis Complete." : "Pending"
            let percentComplete = isCached ? 100 : 0
            select new WorkItem
            {
                Id = document.Id,
                Name = document.Name,
                PercentComplete = percentComplete,
                State = state,
                StatusMessage = statusMessage
            };

        internal static IImmutableSet<Document> ProcessedDocuments { get; set; } = ImmutableHashSet.Create(LASI.Utilities.ComparerFactory.Create<Document>((dx, dy) => dx.Name == dy.Name, d => d.Name.GetHashCode()));

        public static JobStatusMap TrackedJobs { get; } = new JobStatusMap();
        private string ServerPath => System.IO.Directory.GetParent(hostingEnvironment.WebRootPath).FullName;
        private string UserDocumentsDirectory => Path.Combine(ServerPath, "App_Data", "SourceFiles");

        private readonly IDocumentAccessor<UserDocument> documentStore;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IWorkItemsService userWorkItemsService;
        private const string DocumentNotFoundMessage = "No document matching the specified Id could be retrieved";
        private const int MaxChartItems = 10;

    }
}
