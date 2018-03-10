; !(function () {

    " use strict ";

    var root = this;

    var dx = function (obj) {
        if (obj instanceof dx) return obj;
        if (!(this instanceof dx)) return new dx(obj);
        //this._wrapped = obj;
    };

    if (typeof exports !== 'undefined') {
        if (typeof module !== 'undefined' && module.exports) {
            exports = module.exports = dx;
        }
        exports.dx = dx;
    }
    else {
        root.dx = dx;
    }

    dx.VERSION = '1.0.0';

    dx.util = root._;

    dx.util.aaa = function () {
        console.log('aa');
    }

})();