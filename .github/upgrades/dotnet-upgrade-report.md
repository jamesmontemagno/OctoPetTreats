# .NET 9.0 Upgrade Report

## Project modifications

| Project name                                   | Old Target Framework    | New Target Framework         | Commits                   |
|:-----------------------------------------------|:-----------------------:|:----------------------------:|---------------------------|
| MvcPetTreats.csproj                            | net6.0                  | net9.0                       | 4d18ab4e                  |
| RazorPetTreats.csproj                          | net6.0                  | net9.0                       | 4d18ab4e                  |
| WpfPetTreats.csproj                            | net6.0-windows          | net9.0-windows               | 4d18ab4e                  |
| MvcPetTreats.Tests.csproj                      | net6.0                  | net9.0                       | 4d18ab4e                  |
| RazorPetTreats.Tests.csproj                    | net6.0                  | net9.0                       | 4d18ab4e                  |
| WpfPetTreats.Tests.csproj                      | net6.0-windows          | net9.0-windows               | 4d18ab4e                  |

## NuGet Packages

| Package Name                                   | Old Version             | New Version                 | Commit Id                 |
|:-----------------------------------------------|:-----------------------:|:---------------------------:|---------------------------|
| HtmlSanitizer                                  | 7.1.542                 | 9.0.884                     | 4d18ab4e                  |
| Microsoft.Data.SqlClient                       | 4.0.5                   | 6.0.2                       | 4d18ab4e                  |
| Microsoft.EntityFrameworkCore.Design           | 6.0.0-rtm.21467.1       | 9.0.5                       | 4d18ab4e                  |
| Microsoft.EntityFrameworkCore.SqlServer        | 6.0.0-rc.1.21452.10     | 9.0.5                       | 4d18ab4e                  |
| Microsoft.EntityFrameworkCore.Sqlite           | 6.0.0-rc.1.21452.10     | 9.0.5                       | 4d18ab4e                  |
| Microsoft.EntityFrameworkCore.Tools            | 6.0.0-rc.1.21452.10     | 9.0.5                       | 4d18ab4e                  |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 6.0.0-rc.1.21464.1    | 9.0.0                       | 4d18ab4e                  |

## Code Changes

1. Fixed serialization/deserialization in WpfPetTreats:
   - Replaced obsolete `BinaryFormatter` with `System.Text.Json` in `PetTreatManager.cs`
   - Updated test code in `PetTreatManagerTests.cs` to be compatible with JSON serialization

2. Updated namespace references:
   - Changed `Ganss.HtmlSanitizer` to `Ganss.Xss` in multiple files for compatibility with the updated HtmlSanitizer package

## All commits

| Commit ID              | Description                                                      |
|:-----------------------|:-----------------------------------------------------------------|
| 4d18ab4e               | Upgrade projects to .NET 9.0 and update dependencies             |

## Next steps

- Review the WpfPetTreats serialization implementation to ensure it fully meets your requirements
- Consider updating test data in `WpfPetTreats.Tests` projects to better match the new serialization format
- Run a full regression test to ensure all functionality works correctly with .NET 9.0