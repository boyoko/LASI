﻿var app = {};
(function () {
    'use strict';
    var $editor = $('#free-editor');
    $editor.change(function (e) {
    });
    //var account = require('/account/manage'),
    //    widgets = require('/widgets/document-upload');
    app.exports = {
        //account: account,
        //widgets: widgets
    };
    app.log = console.log.bind(console);
    return app;
}(app || {}));