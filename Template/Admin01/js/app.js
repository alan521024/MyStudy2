; !(function (win) {

    " use strict ";

    var root = win;

    var app = function (obj) {
        if (obj instanceof app) return obj;
        if (!(this instanceof app)) return new app(obj);
        //this._wrapped = obj;
    };

    if (typeof exports !== 'undefined') {
        if (typeof module !== 'undefined' && module.exports) {
            exports = module.exports = app;
        }
        exports.app = app;
    }
    else {
        root.app = app;
    }

    app.VERSION = '1.0.0';


})(window);