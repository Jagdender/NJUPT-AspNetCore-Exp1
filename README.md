<h1 align="center"> 
  <br>
  南京邮电大学 ASP.NET应用开发 实验一
  <br>
</h1>

<h3 align="center">Minimal API应用开发</h3>

## 实验要求(2025)

开发⼀个Minimal API应⽤，实现对聚会信息的增删改查。 

具体要求如下：  
聚会信息包括聚会的编号、主题、地点、时间 
- 通过GET /Party/All，查看所有聚会信息 
- 通过GET /Party/id，查看某个id的聚会信息 
- 通过POST /Party，增加新聚会，由应⽤负责分配该聚会的id 
- 通过PUT /Party/id，修改聚会信息 
- 通过DELETE /Party/id，删除某个id的聚会，该id不得分配给后续添加的新聚会

## Feature

- 使用NativeAOT技术，无需运行时，开箱即用
- 文件体积与内存占用都仅需 **10MB** 左右
- 自带一个轻量级的测试页面
- ~因为需求简单~ 性能极其优异

## 测试页面 

程序会检索同文件夹下的 `index.html` 文件

可以在浏览器中访问 `http://localhost:5000/Party` 查看该页面

如果选择部署在服务器上，请更改 `index.html` 中 `<base>` 的地址

## 自编译

在 ~~一般的~~ Linux系统上
```shell
dotnet publish -c Release -r linux-x64 --self-contained true /p:PublishAot=true -o ./output
```

在 ~~一般的~~ Windows系统上
```shell
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishAot=true -o ./output
```

其中  
`-o` 参数表示输出目录  
`-r` 参数表示目标平台  

| Platform   | Available Parameters |
|  :----:    |         :----:       |
| *Windows*  | `win-x64`, `win-arm`, `win-arm64`       |
| *Linux*    | `linux-x64`, `linux-arm`, `linux-arm64` |
| *MacOS*    | `osx-x64`, `osx-arm64`                  |
