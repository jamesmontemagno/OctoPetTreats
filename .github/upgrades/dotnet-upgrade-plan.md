# .NET 9.0 Upgrade Plan

## Execution Steps

1. Validate that an .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade projects to .NET 9.0.
  - 3.1. Upgrade WpfPetTreats\WpfPetTreats.csproj
  - 3.2. Upgrade RazorPetTreats\RazorPetTreats.csproj
  - 3.3. Upgrade MvcPetTreats\MvcPetTreats.csproj
  - 3.4. Upgrade WpfPetTreats.Tests\WpfPetTreats.Tests.csproj
  - 3.5. Upgrade RazorPetTreats.Tests\RazorPetTreats.Tests.csproj
  - 3.6. Upgrade MvcPetTreats.Tests\MvcPetTreats.Tests.csproj
4. Run unit tests to validate upgrade in the projects listed below:
  - MvcPetTreats.Tests\MvcPetTreats.Tests.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

Table below contains projects that do belong to the dependency graph for select projects and would not be included in the upgrade.

| Project name | Description |
|:-------------|:-----------:|
| | |

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name | Current Version | New Version | Description |
|:-------------|:---------------:|:-----------:|:------------|
| Microsoft.Data.SqlClient | 4.0.5 | 6.0.2 | Deprecated package |
| Microsoft.EntityFrameworkCore.Design | 6.0.0-rtm.21467.1 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.EntityFrameworkCore.SqlServer | 6.0.0-rc.1.21452.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.EntityFrameworkCore.Sqlite | 6.0.0-rc.1.21452.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.EntityFrameworkCore.Tools | 6.0.0-rc.1.21452.10 | 9.0.5 | Recommended for .NET 9.0 |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 6.0.0-rc.1.21464.1 | 9.0.0 | Recommended for .NET 9.0 |

### Project upgrade details
This section contains details about each project upgrade and modifications that need to be done in the project.

#### WpfPetTreats\WpfPetTreats.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0` to `net9.0`

#### RazorPetTreats\RazorPetTreats.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0` to `net9.0`

#### MvcPetTreats\MvcPetTreats.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0` to `net9.0`

NuGet packages changes:
  - Microsoft.Data.SqlClient should be updated from `4.0.5` to `6.0.2` (*deprecated package*)
  - Microsoft.EntityFrameworkCore.Design should be updated from `6.0.0-rtm.21467.1` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.SqlServer should be updated from `6.0.0-rc.1.21452.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.Sqlite should be updated from `6.0.0-rc.1.21452.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.Tools should be updated from `6.0.0-rc.1.21452.10` to `9.0.5` (*recommended for .NET 9.0*)
  - Microsoft.VisualStudio.Web.CodeGeneration.Design should be updated from `6.0.0-rc.1.21464.1` to `9.0.0` (*recommended for .NET 9.0*)

#### WpfPetTreats.Tests\WpfPetTreats.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0-windows` to `net9.0-windows`

#### RazorPetTreats.Tests\RazorPetTreats.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0` to `net9.0`

#### MvcPetTreats.Tests\MvcPetTreats.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0` to `net9.0`