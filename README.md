##### | `21WM1B, Web & Mobile Development` | `Laboration 2` | `ASYAR19h` | `Högskolan i Borås 2021` | `Creators`: `Simon Berger-Siroky`, `Thomas Liu` |

### Distributed Task-divided Application *(Applikation för distribuerad uppgiftsfördelning)*

## How-to:
* Download or clone the repository. 
* `localDb` ![#c5f015](https://via.placeholder.com/15/c5f015/000000?text=+) must be installed, otherwise see [here](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15).
* In the DataAccessLayer project directory, type ```dotnet ef migrations add Initial``` for creating the migration, followed by ```dotnet ef database update``` to create the database.
* In your IDE, set multiple startup projects to `TaskManagerApi` ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+) and `TaskManagerWebApp` ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+). To set multiple startup projects in Visual Studio, see [here](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-set-multiple-startup-projects?view=vs-2019).
* Now both the web api and web server are be running. You can download the `Android Client App` ![#1589F0](https://via.placeholder.com/15/1589F0/000000?text=+) and use it, in the Repository root folder `AndroidClientApp`.

## Specification:
The system consists of four parts:
1. `MSSqlLocalDB` ![#c5f015](https://via.placeholder.com/15/c5f015/000000?text=+)
2. `WebApi` ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+)
3. `WebApp (Mvc)` ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+)
4. `Android Client App` ![#1589F0](https://via.placeholder.com/15/1589F0/000000?text=+)

## 1. **MSSqlLocalDB** ![#c5f015](https://via.placeholder.com/15/c5f015/000000?text=+)
Using SQL Server Express LocalDB. [Documentation](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15)

## 2. **WebApi** ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+)
Running .NET 5, C# v9, in Visual Studio 2019. Entity Framework Code-first. 

Repository pattern used in this project.

`Migrations` used with Entity FrameWork (see `How-to` section).

Solution consists of `WebApi`, `WepApp (MVC, see next section)`, `DataAccessLayer (EF Core)` and `Entities (DTO Models)`.

**FrameWorks**:
* `ASP .NET 5`
* `Entity FrameWork Core`

**NuGet packages**: 
* `Microsoft.EntityFrameworkCore.SqlServer`
* `Swashbuckle.AspNetCore`

## 3. **WebApp** ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+)
Running .NET 5, C# v9, in Visual Studio 2019. MVC-pattern. No repository, using database context directly.

**FrameWorks**:
* `ASP .NET 5 MVC`

**NuGet packages**: 
* `Microsoft.EntityFrameworkCore.Design`
* `Microsoft.EntityFrameworkCore.SqlServer`
* `Microsoft.VisualStudio.Web.CodeGeneration.Design`

## 4. **Android Client App** ![#1589F0](https://via.placeholder.com/15/1589F0/000000?text=+)
Running Kotlin vXX, in Android Studio. 
