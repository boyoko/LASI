﻿module LASI.documentList {
    'use strict';

    angular
        .module('documentList')
        .factory('resultsService', resultsService);

    resultsService.$inject = ['$http', '$q'];

    interface ResultsService {
        tasks: Task[];
        processDocument(documentId: string, documentName: string): ng.IPromise<models.DocumentModel>;
    }
    function resultsService($http: ng.IHttpService, $q: ng.IQService): ResultsService {
        var tasks = [];
        var processDocument = function (documentId, documentName): ng.IPromise<models.DocumentModel> {
            tasks[documentId] = { percentComplete: 0 };

            var deferred = $q.defer<models.DocumentModel>();
            $http.get<models.DocumentModel>('Analysis/' + documentId)
                .success(success)
                .error(error);
            return deferred.promise;

            function success(data) {
                var markupHeader = $('<div class="panel panel-default">' +
                    '<div class="panel-heading"><h4 class="panel-title"><a href="#' +
                    documentId +
                    '" data-toggle="collapse" data-parent="#accordion">' +
                    documentName +
                    '</a></h4></div></div>');
                var markupPanel = $('<div id="' + documentId + '" class="panel-collapse collapse in">' +
                    JSON.stringify(data) + '</div>' + '</div>');
                if (!$('#' + documentId).length) {
                    $('#accordion').append(markupHeader).append(markupPanel);
                } else {
                    $('#' + documentId).remove();
                    $('#accordion').append(markupPanel);
                }
                LASI.buildMenus();
                LASI.enableActiveHighlighting();
                tasks[documentId].percentComplete = 100;
                deferred.resolve(data);
            }
            function error(xhr, message, detail) {
                deferred.reject(message);
            }
        };
        return {
            tasks,
            processDocument
        };
    }
}