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

const BOX_AXEL_POSITIONS = {
    left: 'left',
    right: 'right',
    middle: 'middle',
    top: 'top',
    bottom: 'bottom'
};

class BVToastBus {
    constructor() {
        this.__toasts = [];
        this.__portalElements = {
            wrapper: null,
            tl: null,
            tr: null,
            br: null,
            bl: null
        };
    }

    show(element, xPos, yPos) {
        xPos = (BOX_AXEL_POSITIONS[xPos] || BOX_AXEL_POSITIONS.right)[0];
        yPos = (BOX_AXEL_POSITIONS[yPos] || BOX_AXEL_POSITIONS.top)[0];

        utils.setParent(element, this.__portal(xPos, yPos));
        utils.addClass(element, "show");
    }

    hide(element) {
        utils.removeClass(element, "show");
    }

    get __portal() {
        return (xPos, yPos) => {
            const key = `${yPos}${xPos}`;

            if (!this.__portalElements.wrapper) {
                const wrapper = document.createElement("div");
                utils.addClass(wrapper, "bv-toast-portal");
                document.body.appendChild(wrapper);
                this.__portalElements.wrapper = wrapper;
            }

            if (!this.__portalElements[key]) {
                const portal = document.createElement("div");
                utils.addClass(portal, `bv-toast-portal-${key}`);
                this.__portalElements.wrapper.appendChild(portal);
                this.__portalElements[key] = portal;
            }

            return this.__portalElements[key];
        };
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
