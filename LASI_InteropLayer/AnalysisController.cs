﻿using LASI.Core;
using LASI.Core.Binding;
using LASI.Core.DocumentStructures;
using LASI.Core.Heuristics;
using LASI.ContentSystem;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LASI.Interop
{

    /// <summary>
    /// Governs the complete analysis and processing of one or more text sources.
    /// Provides synchronous and asynchronoun callback based progress reports.
    /// </summary>
    public sealed class AnalysisController : Progress<AnalysisProgressReportEventArgs>
    {
        /// <summary>
        /// Gets a Task&lt;IEnumerable&lt;LASI.Algorithm.Document&gt;&gt; which, when awaited, loads, analyizes, and aggregates all of the provided TextFile instances as individual documents, collecting them as
        /// a sequence of Bound and Weighted LASI.Algorithm.Document instances. Progress update logic is specified via an asynchronous function parameter.
        /// </summary>
        /// <returns>A Task&lt;IEnumerable&lt;LASI.Algorithm.Document&gt;&gt;, when awaited, loads and analyizes, and aggregates all of the provided TextFile instances as individual documents, collecting them as
        /// a sequence of Bound and Weighted LASI.Algorithm.Document instances.</returns>
        /// <example>
        ///Example event registration:
        ///<code>
        /// myProcessController.ProgressChanged += async (sender, e) => MsgBox.Show(e.Message + " " + e.Increment);
        /// </code>
        /// </example>
        public async Task<IEnumerable<Document>> ProcessAsync() {

            var taggedFiles = await TagFilesAsync(rawTextSources);
            var result = await BindAndWeightDocumentsAsync(taggedFiles);
            return result;
        }
        /// <summary>
        /// Initializes a new instance of the AnalysisController class.
        /// </summary>
        /// <param name="rawTextSources">A collection of untagged english language written works.</param>
        public AnalysisController(IEnumerable<LASI.Core.IUntaggedTextSource> rawTextSources) {
            this.rawTextSources = rawTextSources;
            this.ProgressChanged += delegate { };
            sourceCount = rawTextSources.Count();
            stepMagnitude = 2d / sourceCount;
            SetupResourceLoadingNotification();
        }
        /// <summary>
        /// Initializes a new instance of the AnalysisController class.
        /// </summary>
        /// <param name="rawTextSource">An untagged english language written work.</param>
        public AnalysisController(IUntaggedTextSource rawTextSource)
            : this(new[] { rawTextSource }) { }

        private void SetupResourceLoadingNotification() {
            Lookup.ResourceLoading -= lookupResourceLoading;
            Lookup.ResourceLoading -= lookupResourceLoaded;

            Lookup.ResourceLoaded += lookupResourceLoading;
            Lookup.ResourceLoaded += lookupResourceLoaded;
        }

        private EventHandler<ResourceLoadedEventArgs> lookupResourceLoaded {
            get {
                return (s, e) => { OnReport(new AnalysisProgressReportEventArgs("Loaded " + e.Message, 1.5)); };
            }
        }
        private EventHandler<ResourceLoadedEventArgs> lookupResourceLoading {
            get {
                return (s, e) => { OnReport(new AnalysisProgressReportEventArgs("Loading " + e.Message, 1.5)); };
            }
        }

        private async Task<ConcurrentBag<ITaggedTextSource>> TagFilesAsync(IEnumerable<LASI.Core.IUntaggedTextSource> rawTextDocuments) {
            OnReport(new AnalysisProgressReportEventArgs("Tagging Documents", 0));
            var tasks = rawTextDocuments.Select(raw => Task.Run(async () => await Tagger.TaggedFromRawAsync(raw))).ToList();
            var taggedFiles = new ConcurrentBag<LASI.Core.ITaggedTextSource>();
            while (tasks.Any()) {
                var task = await Task.WhenAny(tasks);
                var tagged = await task;
                tasks.Remove(task);
                taggedFiles.Add(tagged);
                OnReport(new AnalysisProgressReportEventArgs(string.Format("{0}: Tagged", tagged.Name), stepMagnitude + 1.5));
            }
            OnReport(new AnalysisProgressReportEventArgs("Tagged Documents", 3));
            return taggedFiles;
        }

        private async Task<IEnumerable<Document>> BindAndWeightDocumentsAsync(ConcurrentBag<ITaggedTextSource> taggedFiles) {
            var tasks = taggedFiles.Select(tagged => ProcessTaggedFileAsync(tagged)).ToList();
            var documents = new ConcurrentBag<Document>();
            while (tasks.Any()) {
                var currentTask = await Task.WhenAny(tasks);
                var processedDocument = await currentTask;
                tasks.Remove(currentTask);
                documents.Add(processedDocument);
            }
            return documents;
        }
        private async Task<Document> ProcessTaggedFileAsync(LASI.Core.ITaggedTextSource tagged) {
            var fileName = tagged.Name;
            OnReport(new AnalysisProgressReportEventArgs(string.Format("{0}: Loading...", fileName), 0));
            var document = await Tagger.DocumentFromTaggedAsync(tagged);
            OnReport(new AnalysisProgressReportEventArgs(string.Format("{0}: Loaded", fileName), 4 / sourceCount));
            OnReport(new AnalysisProgressReportEventArgs(string.Format("{0}: Analyzing Syntax...", fileName), 0));
            foreach (var bindingTask in document.GetBindingTasks()) {
                OnReport(new AnalysisProgressReportEventArgs(bindingTask.InitializationMessage, 0));
                await bindingTask.Task;
                OnReport(new AnalysisProgressReportEventArgs(bindingTask.CompletionMessage, bindingTask.PercentWorkRepresented * 0.5 / sourceCount));
            }
            OnReport(new AnalysisProgressReportEventArgs(string.Format("{0}: Correlating Relationships...", fileName), 0));
            foreach (var task in document.GetWeightingTasks()) {
                OnReport(new AnalysisProgressReportEventArgs(task.InitializationMessage, 1 / sourceCount));
                await task.Task;
                OnReport(new AnalysisProgressReportEventArgs(task.CompletionMessage, task.PercentWorkRepresented * 0.5 / sourceCount));
            }

            OnReport(new AnalysisProgressReportEventArgs(string.Format("{0}: Completing Parse...", fileName), stepMagnitude));
            return document;
        }



        #region Fields

        private double sourceCount;
        private double stepMagnitude;
        private IEnumerable<IUntaggedTextSource> rawTextSources;

        #endregion


    }
    #region Helper Types
    /// <summary>
    /// Contains event data regarding the current state and progress of analysis.
    /// </summary>
    [Serializable]
    [System.Runtime.InteropServices.ComVisible(true)]
    public class AnalysisProgressReportEventArgs : LASI.Core.Interop.Reporting.ReportEventArgs
    {
        internal AnalysisProgressReportEventArgs(string message, double increment) {
            Message = message;
            Increment = increment;
        }
        /// <summary>
        /// Gets a message indicating the phase of analysis underway when they Report was created.
        /// </summary>
        public override string Message { get; protected set; }
        /// <summary>
        /// Gets a value indicating the amount by which overall progress of analysis has increased since the last Report was created.
        /// </summary>
        public override double Increment { get; protected set; }
    }

    #endregion

}

