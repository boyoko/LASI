/// <reference path = '../../typings/angular-bootstrap-contextMenu/angular-bootstrap-contextmenu.d.ts'/>
var contextmenuTests;
(function (contextmenuTests) {
    'use strict';
    var item1 = [
        function (s, e) { return 'item1'; },
        function (s, e) { return console.log('item1 clicked'); },
        function (s, e) { return true; }
    ];
    var item2 = [
        'item2',
        function (s) { return console.log(s); }
    ];
    var item3 = [
        'item3',
        function (s, e) { return console.log('item3 clicked'); },
        function (s, e) { return Object.keys(s).every(function (k1) { return Object.keys(e).some(function (k2) { return k1 === k2; }); }); }
    ];
    var menu = [
        item1, item2
    ];
})(contextmenuTests || (contextmenuTests = {}));
//# sourceMappingURL=contextmenu-definitions-tests.js.map