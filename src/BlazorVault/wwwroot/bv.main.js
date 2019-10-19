"use strict";

const utils = {
    addClass: function (el, className) {
        if (className && el.classList) {
            el.classList.add(className);
        } 
    },
    removeClass: function (el, className) {
        if (className && el.classList) {
            el.classList.remove(className);
        }
    },
    hasClass: function (el, className) {
        if (className && el.classList) {
            return el.classList.indexOf(className) !== -1;
        }
        return false;
    }
};

class BVToggleBus {
    constructor() {
        this.__collapsables = [];
    }

    assign(element) {
        this.__collapsables.push(element);
    }

    show(elementId) {
        let target = this.findTarget(elementId);
        if (target) {
            utils.addClass(target, 'show');
        }
    }

    hide(elementId) {
        let target = this.findTarget(elementId);
        if (target) {
            utils.removeClass(target, 'show');
        }
    }

    findTarget(elementId) {
        return this.__collapsables.find(x => x.id === elementId);
    }
}

window.bv = {
    toggle: new BVToggleBus()
};
