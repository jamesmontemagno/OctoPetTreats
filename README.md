# Treats Application (.NET 6)

This repository contains a .NET 6 solution for managing pet treats, demonstrating both ASP.NET Core MVC and Razor Pages architectures, along with related unit tests.

## Solution Overview

### 1. MvcPetTreats
- **Type:** ASP.NET Core MVC Web App
- **Purpose:** Manages pet treats using controllers, views, and models. Supports CRUD operations for treats, with data stored in a database via Entity Framework Core.
- **Key Features:**
  - Controllers for treat management (e.g., `PetTreatsController`)
  - Entity Framework Core for data access
  - MVC views for user interaction
  - Data seeding and migrations

### 2. RazorPetTreats
- **Type:** ASP.NET Core Razor Pages Web App
- **Purpose:** Provides a Razor Pages interface for pet treats, with a focus on security and modern web practices.
- **Key Features:**
  - Razor Pages for page-centric development
  - Integrated HTML sanitization (`HtmlSanitizer`)
  - IP-based rate limiting for security
  - Shared services for safe content rendering

### 3. MvcPetTreats.Tests
- **Type:** Unit Test Project (nUnit)
- **Purpose:** Contains unit tests for the MVC application, ensuring controller logic and other components work as expected.
- **Key Features:**
  - Tests for controller actions (e.g., `HelloWorldController`)

### 4. RazorPetTreats.Tests
- **Type:** Unit Test Project (MSTest)
- **Purpose:** Contains unit tests for the Razor Pages application, focusing on shared services and security features.
- **Key Features:**
  - Tests for the `Safe` service and HTML sanitization

## Getting Started

1. Clone the repository.
2. Restore dependencies with `dotnet restore`.
3. Run the desired app using `dotnet run` from either `MvcPetTreats` or `RazorPetTreats`.
4. Visit the provided URL in your browser.

## Notes
- Both web apps target .NET 6 and demonstrate best practices for their respective architectures.
- The solution is designed for learning, experimentation, and upgrade scenario exploration.
- For documentation, refer to the official ASP.NET Core guides.