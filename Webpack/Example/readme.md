### 基础示例
> 说明： 该示例为一个基础的webapck演示

1.安装Node.js

>新版nodejs npm会一起安装(旧版本：npm install npm -g 升级或使用淘宝镜像的命令：cnpm install npm -g)

>使用淘宝 NPM 镜像：npm install -g cnpm --registry=https://registry.npm.taobao.org 

>运行 cmd 命令提示符：输入 node -v  /  npm -v 查看版本号 验证安装是否成功 

2.新建应用/项目文件夹(eg:D:/test1)

> 在命令提示符中，将环境切换到项目文件夹 

> 小提示：在资源管理器 *地址栏中输入 cmd 回车*

3.运行 cnpm init -y 初始并生成 package.json 文件

4.运行 cnpm install --save-dev webpack 安装 webpack

5.新建 **public** 目录放置打包后的文件,新建 **script** 目录放置源文件 (注：名称可自定义eg: src/dis)

6.新建 *功能示例 module1.js*（script/module1.js)

````
module.exports = function () {
    var elm = document.createElement('div');
    elm.textContent = "创建一个div ，这里Div内容";
    return elm;
}
````

7.新建 *入口示例 main.js* (名称可自定义 eg:app.js)

````
const m1=require("./script/module1.js")
document.querySelector("#root").appendChild(m1());
````

8.新建 *页面示例 index.html*

* 注：index.html 引用的是public/bundle.js 这是打包后的文件，在第9点output配置

````
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>示例</title>
</head>
<body>
    <div id='root'></div>
    <script src="public/bundle.js"></script>
</body>
</html>
````

9.新建 *配置文件 webpack.config.js*

```
module.exports = {
    devtool: "eval-source-map",
    entry: __dirname + "/main.js",
    output: {
        path: __dirname + "/public",
        filename: "bundle.js"
    }
}
````

10.修改 package.json > scripts 节点 增加 "start": "webpack"

````
{
  "name": "Example",
  "version": "1.0.0",
  "description": "> 说明： 该示例为一个基础的webapck演示",
  "main": "index.js",
  "scripts": {
    "start": "webpack",
    "test": "echo \"Error: no test specified\" && exit 1"
  },
  "keywords": [],
  "author": "",
  "license": "ISC",
  "devDependencies": {
    "webpack": "^3.10.0"
  }
}
````

11.运行 打包命令 cnpm start 在 *public* 文件夹生成打包后文件 