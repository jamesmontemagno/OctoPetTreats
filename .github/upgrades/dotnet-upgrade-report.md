# .NET 9.0 Upgrade Report

## Project modifications

| Project name                           | Old Target Framework | New Target Framework | Commits                        |
|:--------------------------------------|:-------------------:|:--------------------:|--------------------------------|
| WpfPetTreats\WpfPetTreats.csproj      | net6.0              | net9.0               | 655c61a5                       |
| RazorPetTreats\RazorPetTreats.csproj  | net6.0              | net9.0               | 655c61a5                       |
| MvcPetTreats\MvcPetTreats.csproj      | net6.0              | net9.0               | 655c61a5                       |
| WpfPetTreats.Tests\WpfPetTreats.Tests.csproj | net6.0-windows | net9.0-windows     | 655c61a5                       |
| RazorPetTreats.Tests\RazorPetTreats.Tests.csproj | net6.0    | net9.0              | 655c61a5                       |
| MvcPetTreats.Tests\MvcPetTreats.Tests.csproj | net6.0        | net9.0              | 655c61a5                       |

## NuGet Packages

| Package Name                                  | Old Version          | New Version | Commit Id |
|:---------------------------------------------|:--------------------:|:-----------:|-----------|
| Microsoft.Data.SqlClient                      | 4.0.5                | 6.0.2       | 655c61a5  |
| Microsoft.EntityFrameworkCore.Design         | 6.0.0-rtm.21467.1    | 9.0.5       | 655c61a5  |
| Microsoft.EntityFrameworkCore.SqlServer      | 6.0.0-rc.1.21452.10  | 9.0.5       | 655c61a5  |
| Microsoft.EntityFrameworkCore.Sqlite         | 6.0.0-rc.1.21452.10  | 9.0.5       | 655c61a5  |
| Microsoft.EntityFrameworkCore.Tools          | 6.0.0-rc.1.21452.10  | 9.0.5       | 655c61a5  |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 6.0.0-rc.1.21464.1 | 9.0.0      | 655c61a5  |

## Code Changes

1. **WpfPetTreats\Services\PetTreatManager.cs**: 
   - Replaced obsolete `BinaryFormatter` with `System.Text.Json` for serialization and deserialization
   - Added `JsonSerializerOptions` with `WriteIndented` for better formatting
   - Updated serialization and deserialization methods to use JSON

2. **RazorPetTreats\Extensions\HtmlSanitizerExtensions.cs** and **RazorPetTreats\SharedServices\Safe.cs**:
   - Fixed namespace casing by replacing `Ganss.XSS` with `Ganss.Xss`

3. **RazorPetTreats.Tests\SafeTest.cs**:
   - Updated references to HTML sanitizer namespace

## Test Results

| Project | Passed | Failed | Skipped |
|:--------|:------:|:------:|:-------:|
| MvcPetTreats.Tests | 2 | 0 | 0 |

## All commits

| Commit ID              | Description                                |
|:-----------------------|:-------------------------------------------|
| 655c61a5               | Upgrade to .NET 9 and update dependencies  |

## Next steps

- Review the serialization changes in `PetTreatManager.cs` as they may not be compatible with existing serialized data
- Consider updating test coverage for the modified serialization code
- Monitor application performance after upgrading to .NET 9.0
- Update any CI/CD pipelines to use .NET 9.0 SDK