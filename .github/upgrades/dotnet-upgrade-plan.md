# .NET 9.0 Upgrade Plan

## Execution Steps

1. Validate that an .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade projects to .NET 9.0.
  - 3.1. Upgrade MvcPetTreats.csproj
  - 3.2. Upgrade MvcPetTreats.Tests.csproj
4. Run unit tests to validate upgrade in the projects listed below:
  - MvcPetTreats.Tests.csproj
  - RazorPetTreats.Tests.csproj
  - WpfPetTreats.Tests.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

Table below contains projects that do belong to the dependency graph for select projects and would not be included in the upgrade.

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                 | Current Version          | New Version | Description                         |
|:---------------------------------------------|:------------------------:|:-----------:|:------------------------------------|
| Microsoft.Data.SqlClient                     | 4.0.5                    | 6.0.2       | Deprecated                          |
| Microsoft.EntityFrameworkCore.Design         | 6.0.0-rtm.21467.1        | 9.0.5       | Recommended for .NET 9.0            |
| Microsoft.EntityFrameworkCore.SqlServer      | 6.0.0-rc.1.21452.10      | 9.0.5       | Recommended for .NET 9.0            |
| Microsoft.EntityFrameworkCore.Sqlite         | 6.0.0-rc.1.21452.10      | 9.0.5       | Recommended for .NET 9.0            |
| Microsoft.EntityFrameworkCore.Tools          | 6.0.0-rc.1.21452.10      | 9.0.5       | Recommended for .NET 9.0            |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 6.0.0-rc.1.21464.1   | 9.0.0       | Recommended for .NET 9.0            |

### Project upgrade details
This section contains details about each project upgrade and modifications that need to be done in the project.

#### MvcPetTreats.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0` to `net9.0`

NuGet packages changes:
  - Microsoft.Data.SqlClient should be updated from `4.0.5` to `6.0.2` (*deprecated*)
  - Microsoft.EntityFrameworkCore.Design should be updated from `6.0.0-rtm.21467.1` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.SqlServer should be updated from `6.0.0-rc.1.21452.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.Sqlite should be updated from `6.0.0-rc.1.21452.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.Tools should be updated from `6.0.0-rc.1.21452.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.VisualStudio.Web.CodeGeneration.Design should be updated from `6.0.0-rc.1.21464.1` to `9.0.0` (*recommended for .NET 9.0*)

#### MvcPetTreats.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0` to `net9.0`