module.exports = {
    devtool: "eval-source-map",                     //source map 选项(正式环境取消)
    entry: __dirname + "/ClientApp/main.js",        //已多次提及的唯一入口文件
    output: {
        path: __dirname + "/ClientApp/public",      //打包后的文件存放的地方
        filename: "bundle.js"                       //打包后输出文件的文件名
    }
}