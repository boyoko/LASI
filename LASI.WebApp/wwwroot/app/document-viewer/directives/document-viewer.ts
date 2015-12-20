﻿'use strict';
import template from 'app/document-viewer/directives/document-viewer.html';
export function documentViewer(): angular.IDirective {
    return {
        restrict: 'E',
        template,
        scope: { document: '=' }
    };
}