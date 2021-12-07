<h1 align="center" style="max-width:100%; color: #2b2301;" height="140" >
  IronHook
</h1>


<p align="center">
  <a href="https://gitmoji.carloscuesta.me">
    <img src="https://img.shields.io/badge/gitmoji-%20😜%20😍-FFDD67.svg?style=flat-square" alt="Gitmoji">
  </a> 
</p>


| Source     | Badges                |
| :------- | :------------------------- |
| `Code Quality` | [![Maintainability](https://api.codeclimate.com/v1/badges/488c665bd42410a26780/maintainability)](https://codeclimate.com/github/FowApps/IronHook/maintainability) [![Test Coverage](https://api.codeclimate.com/v1/badges/488c665bd42410a26780/test_coverage)](https://codeclimate.com/github/FowApps/IronHook/test_coverage)|
| `Stats For PostgreSQL` | [![Nuget](https://img.shields.io/nuget/dt/IronHook.PostgreSql?label=IronHook.PostgreSql%20Downloads)](https://www.nuget.org/packages/IronHook.PostgreSql/) [![Nuget](https://img.shields.io/nuget/v/IronHook.PostgreSql?label=IronHook.PostgreSql)](https://www.nuget.org/packages/IronHook.PostgreSql/) |
| `Stats For Core` | [![Nuget](https://img.shields.io/nuget/dt/IronHook.Core?label=IronHook.Core%20Downloads)](https://www.nuget.org/packages/IronHook.Core/) [![Nuget](https://img.shields.io/nuget/v/IronHook.Core?label=IronHook.Core)](https://www.nuget.org/packages/IronHook.Core/) |
| `Stats For EF-Core` | [![Nuget](https://img.shields.io/nuget/dt/IronHook.EntityFrameworkCore?label=IronHook.EntityFrameworkCore%20Downloads)](https://www.nuget.org/packages/IronHook.EntityFrameworkCore/) [![Nuget](https://img.shields.io/nuget/v/IronHook.EntityFrameworkCore?label=IronHook.EntityFrameworkCore)](https://www.nuget.org/packages/IronHook.EntityFrameworkCore/) |
| `License` | [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)  |
| `CI` | [![.NET](https://github.com/FowApps/IronHook/actions/workflows/dotnet.yml/badge.svg)](https://github.com/FowApps/IronHook/actions/workflows/dotnet.yml)  |
| `Languages` | [![GitHub top language](https://img.shields.io/github/languages/top/FowApps/IronHook)](https://github.com/FowApps/IronHook/) |
| `Github Activity` | [![GitHub commit activity](https://img.shields.io/github/commit-activity/y/FowApps/IronHook)](https://github.com/FowApps/IronHook/graphs/commit-activity) [![GitHub contributors](https://img.shields.io/github/contributors/FowApps/IronHook)](https://github.com/FowApps/IronHook/graphs/contributors) [![GitHub last commit](https://img.shields.io/github/last-commit/FowApps/IronHook)](https://github.com/FowApps/IronHook/graphs/commit-activity) [![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/FowApps/IronHook)](https://github.com/FowApps/IronHook/) [![GitHub repo size](https://img.shields.io/github/repo-size/FowApps/IronHook)](https://github.com/FowApps/IronHook/) |
| `Issue Tracking` | [![GitHub issues](https://img.shields.io/github/issues/FowApps/IronHook)](https://github.com/FowApps/IronHook/issues) [![GitHub closed issues](https://img.shields.io/github/issues-closed/FowApps/IronHook)](https://github.com/FowApps/IronHook/issues?q=is%3Aissue+is%3Aclosed) [![GitHub pull requests](https://img.shields.io/github/issues-pr/FowApps/IronHook)](https://github.com/FowApps/IronHook/pulls) [![GitHub closed pull requests](https://img.shields.io/github/issues-pr-closed/FowApps/IronHook)](https://github.com/FowApps/IronHook/pulls?q=is%3Apr+is%3Aclosed) |

***

## Purpose
This repo provides easily management hook operations of for dotnet application.

***

### Supported Databases
- PostgreSql

### Planned Databases
- Sql Server
- MariaDb
- MySql
- SQLite
- Mongo

***

### Getting Started
Install `IronHook.EntityFramework.PostgreSql` from [Nuget Package](https://www.nuget.org/packages/IronHook.PostgreSql)

Initalize `Startup` configuration.

```csharp
services.AddIronHook(options =>
{
   options.UseNpgsql(
     Configuration.GetConnectionString("{YOUR_CONNECTION_STRING}"),
   	 opts => opts.UseIronHookNpgsqlMigrations()
   );
});
```

after

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
  app.MigrateIronHook();
  // ...
}
```

Now you can start hook operations.

***


### Documentation
Visit [Wiki](https://github.com/FowApps/IronHook/wiki) page for documentation.

***
### Demo
Visit [Live Demo](https://iron-hook.herokuapp.com) for sample project.


## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://furkangungor.krawl.me/"><img src="https://avatars.githubusercontent.com/u/47147484?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Furkan Güngör</b></sub></a><br /><a href="#infra-furkandeveloper" title="Infrastructure (Hosting, Build-Tools, etc)">🚇</a> <a href="https://github.com/FowApps/IronHook/commits?author=furkandeveloper" title="Tests">⚠️</a> <a href="https://github.com/FowApps/IronHook/commits?author=furkandeveloper" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/ferhatozlu"><img src="https://avatars.githubusercontent.com/u/4699094?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Ferhat Özlü</b></sub></a><br /><a href="#infra-ferhatozlu" title="Infrastructure (Hosting, Build-Tools, etc)">🚇</a> <a href="https://github.com/FowApps/IronHook/commits?author=ferhatozlu" title="Tests">⚠️</a> <a href="https://github.com/FowApps/IronHook/commits?author=ferhatozlu" title="Code">💻</a></td>
    <td align="center"><a href="https://sercanuste.com"><img src="https://avatars.githubusercontent.com/u/5119317?v=4?s=100" width="100px;" alt=""/><br /><sub><b>Sercan Üste</b></sub></a><br /><a href="https://github.com/FowApps/IronHook/commits?author=sercanuste" title="Documentation">📖</a> <a href="#design-sercanuste" title="Design">🎨</a> <a href="#example-sercanuste" title="Examples">💡</a></td>
  </tr>
</table>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
