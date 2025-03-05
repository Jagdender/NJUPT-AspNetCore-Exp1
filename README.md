# 南京邮电大学 ASP.NET应用开发 实验一

**Minimal API 应用开发**

本项目使用NativeAOT，无需依赖.NET运行时，十分甚至九分的轻量。

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
可用的选项包括：
- `linux-x64`
- `win-x64`
- `osx-x64`
- `linux-arm`
- `linux-arm64`
- `win-arm`
- `win-arm64`
