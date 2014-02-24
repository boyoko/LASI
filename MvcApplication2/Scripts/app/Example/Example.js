﻿(function () {
    "use strict";
    var configureRelationshipMenu = function ($controls, relatedElementIds, elementAction) {
        $controls.each(function (index, element) {
            if (relatedElementIds) {
                $(element).show();
            } else {
                $(element).hide();
            }
        }).click(function (el) {
            el.preventDefault();

            relatedElementIds.map(function (element, index) {
                return $("#" + element.toString());
            }).forEach(elementAction);
        });
    };

    $(function () {
        var verbals = $("span.Verbal");
        var contextMenu = $("#contextMenu");
        var relatedElementAction = function (element, index) {
            $(element).addClass('selected');
        };
        verbals.on("contextmenu", function (e) {
            var relationshipInfo;
            e.preventDefault();
            $("span").removeClass('selected');
            relationshipInfo = $.parseJSON($.trim($(e.target).children("span").text()));
            contextMenu.css({
                position: "absolute",
                display: "block",
                left: e.pageX,
                top: e.pageY
            });
            configureRelationshipMenu(contextMenu.find("ul").children(".view-subects-menu-item"), relationshipInfo.Subjects, relatedElementAction);
            configureRelationshipMenu(contextMenu.find("ul").children(".view-directobjects-menu-item"), relationshipInfo.DirectObjects, relatedElementAction);
            configureRelationshipMenu(contextMenu.find("ul").children(".view-indirectobjects-menu-item"), relationshipInfo.IndirectObjects, relatedElementAction);

            return false;
        });




        $(document).click(function (e) {
            e.preventDefault();

            contextMenu.hide(); contextMenu.find("li").off();
        });
    });
    //$(".view-subects-menu-item").click(function (data) { })
}());