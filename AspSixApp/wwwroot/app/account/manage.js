﻿(function () {
    'use strict';
    $(function () {
        $('#cancel-profile-edits').click(function () {
            document.location.href = 'http://' + document.domain + ':' + document.location.port;
        });
    });
}());