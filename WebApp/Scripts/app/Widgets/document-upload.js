var LASI;
(function (LASI) {
    var Widgets;
    (function (Widgets) {
        var DocumentUpload;
        (function (DocumentUpload) {
            'use strict';
            //var $ = require('/Scripts\jquery-2.1.1.min.js');
            $(function () {
                var $uploadElement = $('#document-upload-input'), $uploadList = $('#document-upload-list'), $uploadButton = $('#document-upload-button');
                $(document).on('change', '.btn-file :file', function () {
                    var $input = $(this);
                    var fileCount = $uploadList.find('span.file-index').length;
                    var files = $input[0].files;
                    $(files).toArray().filter(function (file) { return !$uploadList.children('span').filter(function (index, span) { return $(span).text() === file.name; }).length; }).forEach(function (file, index) {
                        $uploadList.append('<div class="list-group-item text-left">' + '<span class="glyphicon glyphicon-remove remove-file"/>&nbsp;&nbsp;&nbsp;<span class="file-index">' + (fileCount + index + 1) + '</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="file-name">' + file.name + '</span></div>');
                        $('span.glyphicon.glyphicon-remove.remove-file').click(function (e) {
                            $(this).removeData(file.name);
                            $(this).parent().parent().find('span.file-name').filter(function (index, span) { return $(span).text() === file.name; }).each(function (index, f) { return $(f).parent('div').remove(); });
                            $uploadList.find('span.file-index').toArray().forEach(function (e, index) {
                                $(e).text(index + 1);
                            });
                        });
                    });
                    var label = $input.val().replace(/\\/g, '/').replace(/.*\//, '');
                    $input.trigger('fileselect', [files && files.length, label]);
                });
            });
        })(DocumentUpload = Widgets.DocumentUpload || (Widgets.DocumentUpload = {}));
    })(Widgets = LASI.Widgets || (LASI.Widgets = {}));
})(LASI || (LASI = {}));
//# sourceMappingURL=document-upload.js.map