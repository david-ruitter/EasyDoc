# EasyDoc :pencil:
EasyDoc is a tool to export Code Documentation into other formats.
I was inspired to create this Project because javadoc only allowed to export the Documentation into a pre-defined html page.

### Installation
```shell
git clone https://github.com/david-ruitter/EasyDoc.git
```

```shell
cd EasyDoc/src/EasyDoc
```

```shell
dotnet pack
```

```shell
dotnet tool install --global --add-source .\EasyDoc\nupkg\ easydoc
```

### Currently supported
Programming Languages:
- Java

Export Formats:
- JSON
