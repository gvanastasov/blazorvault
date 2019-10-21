"use strict";

window['Blazor'].app = {
    openGates: function (elementId) {
        var element = document.getElementById(elementId);
        setTimeout(function () {
            element.classList.add("open");
        }, 500);
    }
};
