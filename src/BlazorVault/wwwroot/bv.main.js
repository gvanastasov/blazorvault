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
    },
    setParent: function (el, newParent) {
        if (el && newParent) {
            newParent.appendChild(el);
        }
    }
};

class BVToastBus {
    constructor() {
        this.__toasts = [];
        this.__portalElement = null;
    }

    show(element) {
        // teleport
        utils.setParent(element, this.__portal);
        // assign classes
        utils.addClass(element, "show");
    }

    hide(element) {
        utils.removeClass(element, "show");
    }

    get __portal() {
        if (!this.__portalElement) {
            this.__portalElement = document.createElement("div");
            utils.addClass(this.__portalElement, "bv-toast-portal");

            document.body.appendChild(this.__portalElement);
        }

        return this.__portalElement;
    }
}

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
    toggle: new BVToggleBus(),
    toast: new BVToastBus()
};
