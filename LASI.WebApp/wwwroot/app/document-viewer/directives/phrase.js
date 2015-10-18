/// <amd-dependency path='./phrase.html' />
'use strict';
System.register(['./phrase.html'], function(exports_1) {
    var phrase_html_1;
    function phrase(lexicalMenuBuilder) {
        return {
            restrict: 'E',
            template: phrase_html_1.default,
            scope: {
                phrase: '=',
                parentId: '='
            },
            link: link
        };
        function link(scope, element, attrs) {
            var contextmenu = lexicalMenuBuilder.buildAngularMenu(scope.phrase.contextmenu);
            scope.phrase.hasContextmenuData = !!contextmenu;
            if (scope.phrase.hasContextmenuData) {
                scope.phrase.contextmenu = contextmenu;
            }
        }
    }
    exports_1("default", phrase);
    return {
        setters:[
            function (phrase_html_1_1) {
                phrase_html_1 = phrase_html_1_1;
            }],
        execute: function() {
            phrase.$inject = ['lexicalMenuBuilder'];
        }
    }
});
//# sourceMappingURL=phrase.js.map