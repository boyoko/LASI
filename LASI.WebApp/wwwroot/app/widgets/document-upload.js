/// <reference path="../../../typings/jquery/jquery.d.ts" />
/// <reference path="../lasi.ts" />
(function (app) {
    'use strict';
    app.validateFileExtension = (function () {
        var accepted = Object.freeze(['.txt', '.docx', '.pdf', 'doc']);
        return function (fileName) {
            var extension = fileName.substring(fileName.lastIndexOf('.')).toLowerCase();
            return accepted.some(function (ext) {
                return ext === extension;
            });
        };
    })();
    $(function () {
        var $uploadList = $('#document-upload-list');
        app.$uploadList = $uploadList;
        $(document)
            .find('.btn-file :file')
            .change(function () {
            var $input = $(this), fileCount = $uploadList.find('span.file-index').length, files = $input[0].files;
            app.files = files;
            app.fileCount = fileCount;
            var generateUploadListItemMarkup = function (file, index) {
                return '<div class="list-group-item text-left">' +
                    '<span class="glyphicon glyphicon-remove remove-file"/>' +
                    '&nbsp;&nbsp;&nbsp;<span class="file-index">' +
                    [fileCount, index, 1].sum() +
                    '</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="file-name">' +
                    file.name + '</span></div>';
            }, label = $input.val().replace(/\\/g, '/').replace(/[.]*\//, '');
            $(files).filter(function (index, element) { return app.validateFileExtension(element.name); })
                .toArray()
                .filter(function (file) {
                return !($uploadList.children('span').toArray().some(function () {
                    return $(this).text() === file.name;
                }));
            }).forEach(function (file, index) {
                $uploadList.append(generateUploadListItemMarkup(file, index));
                $('span.glyphicon.glyphicon-remove.remove-file')
                    .click(function () {
                    $(this).removeData(file.name)
                        .parent()
                        .parent()
                        .find('span.file-name')
                        .filter(function () { return $(this).text() === file.name; })
                        .each(function () { return $(this).parent('div').remove(); });
                    $uploadList.find('span.file-index')
                        .each(function (index) { $(this).text(index + 1); });
                });
            });
            $input.trigger('fileselect', [files && files.length, label]);
        });
    });
})(LASI);