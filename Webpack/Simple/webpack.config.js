const path = require("path");
const webpack = require("webpack");

module.exports = {
    devtool: "eval-source-map",
    entry: __dirname + "/main.js",
    output: {
        path: __dirname + "/public",
        filename: "bundle.js"
    }
}