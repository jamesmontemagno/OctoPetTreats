# .NET 9.0 Upgrade Report

## Project modifications

| Project name                        | Old Target Framework    | New Target Framework    | Commits                          |
|:-----------------------------------|:----------------------:|:----------------------:|----------------------------------|
| MvcPetTreats.csproj                | net6.0                 | net9.0                 | 998f2e5a                         |
| MvcPetTreats.Tests.csproj          | net6.0                 | net9.0                 | 998f2e5a                         |
| RazorPetTreats.csproj              | *Manual modification*  | net9.0                 | Manual modification              |
| RazorPetTreats.Tests.csproj        | *Manual modification*  | net9.0                 | Manual modification              |

## NuGet Packages

| Package Name                                 | Old Version          | New Version | Commit ID                        |
|:---------------------------------------------|:--------------------:|:-----------:|----------------------------------|
| Microsoft.Data.SqlClient                     | 4.0.5                | 6.0.2       | 998f2e5a                         |
| Microsoft.EntityFrameworkCore.Design         | 6.0.0-rtm.21467.1    | 9.0.5       | 998f2e5a                         |
| Microsoft.EntityFrameworkCore.SqlServer      | 6.0.0-rc.1.21452.10  | 9.0.5       | 998f2e5a                         |
| Microsoft.EntityFrameworkCore.Sqlite         | 6.0.0-rc.1.21452.10  | 9.0.5       | 998f2e5a                         |
| Microsoft.EntityFrameworkCore.Tools          | 6.0.0-rc.1.21452.10  | 9.0.5       | 998f2e5a                         |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 6.0.0-rc.1.21464.1 | 9.0.0     | 998f2e5a                         |

## All commits

| Commit ID              | Description                                                        |
|:-----------------------|:-------------------------------------------------------------------|
| 998f2e5a               | Upgrade MvcPetTreats.csproj properties and items to match net9.0   |
| 998f2e5a               | Upgrade MvcPetTreats.csproj dependencies                           |
| 998f2e5a               | Validate NuGet restore state and fix any restore errors            |
| 998f2e5a               | Upgrade MvcPetTreats.csproj code and replace unsupported API       |
| 998f2e5a               | Upgrade MvcPetTreats.Tests.csproj properties and items to match net9.0 |
| 998f2e5a               | Upgrade MvcPetTreats.Tests.csproj code and replace unsupported API |
| 998f2e5a               | Upgrade MvcPetTreats.Tests.csproj dependencies                     |

## Manual Changes

1. Updated namespace from `Ganss.XSS` to `Ganss.Xss` in the following files:
   - RazorPetTreats\SharedServices\Safe.cs
   - RazorPetTreats\Extensions\HtmlSanitizerExtensions.cs
   - RazorPetTreats.Tests\SafeTest.cs

2. Updated NUnit test assertions in WpfPetTreats.Tests project files to use NUnit 4.0 syntax:
   - Changed `Assert.AreEqual(expected, actual)` to `Assert.That(actual, Is.EqualTo(expected))`
   - Changed `Assert.IsNotNull(actual)` to `Assert.That(actual, Is.Not.Null)`
   - Changed `Assert.IsNotEmpty(actual)` to `Assert.That(actual, Is.Not.Empty)`

3. Updated test data in WpfPetTreats.Tests\PetTreatManagerTests.cs to use JSON serialization format instead of BinaryFormatter.

## Next steps

1. **Verify Application Functionality**: Thoroughly test your upgraded application to ensure all features are working correctly.

2. **Consider Modern Alternatives**: Review remaining deprecated APIs (like HtmlSanitizer) and consider migrating to more modern alternatives.

3. **Adopt .NET 9 Features**: Explore and adopt new features and performance improvements available in .NET 9.

4. **Update CI/CD**: Update your build and deployment pipelines to use .NET 9 SDK.

5. **Update Documentation**: Update any development and deployment documentation to reflect the new .NET version.