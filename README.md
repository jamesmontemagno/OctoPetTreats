# MvcMovieSampleNet6

This repository hosts a .NET 6 web app derived from the ASP.NET Core MVC movie sample. It demonstrates fundamental practices for building an MVC application, including models, views, and controllers.

## Purpose

This project explores potential upgrade challenges when moving from .NET 6 to newer versions. It includes modifications to exhibit various learning opportunities and ensure a smoother transition to future .NET releases.

## Getting Started

1. Clone the repository.
2. Restore dependencies with `dotnet restore`.
3. Run the app using `dotnet run`.
4. Visit the provided URL in your browser.

## Notes

* This project is based on the original ASP.NET Core MVC movie sample from Microsoft.  
* Minimal changes have been introduced to learn about upgrade issues and best practices.  
* For documentation, refer to the official ASP.NET Core guides.
* For research purposes, this project intentionally references an out of date version of HtmlSanitizer.

## Solution structure

1. MvcMovie: an ASP.NET Core 6.0 MVC web app. This app performs CRUD operations on the `Movie` model in SQL Server.
1. MvcMovie.Tests: an nUnit test project for the MVC web app.
1. RazorMovie: an ASP.NET Core 6.0 Razor Pages web app. This app uses HtmlSanitizer.
1. RazorMovie.Tests: an MSTest project for the Razor web app.
1. WpfMovie: a Windows Presentation Framework app that presents a form for editing in-memory `Movie` models.
1. WpfMovie.Tests: an nUnit test project for the WPF project.

## Interesting upgrade scenarios

1. The WpfMovie project uses BinaryFormatter which is removed from .NET9 and deprecated in .NET8
1. The upgrade must choose the correct TFM for the WPF project, and retain the OS specific TFM for the test project.
1. The HtmlSanitizer reeference in the RazorMovie project is intentionally out of date, and upgrading it causes a namespace change that can confuse some tools.
1. The upgrade of the MvcMovie project is expected to be the easiest scenario but the upgrade must still resolve any transitive challenges that surface from Microsoft.Data.SqlClient.
1. The upgrade must choose which NuGet packages to upgrade. And, in this scenario upgrading from nUnit3 to newer version has a breaking change for the `Assert.That` API replacing `Assert.AreEqual`.
1. Azure Functions project upgraded to .NET 9 should select the correct NuGet packages or it will produce a compile error.
1. Azure Functions project upgrade should replace Newtonsoft to resolve the compile error.