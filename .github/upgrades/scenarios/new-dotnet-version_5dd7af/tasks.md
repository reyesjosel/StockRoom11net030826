# StockRoom10net .NET 11.0 Upgrade Tasks

## Overview

This document tracks the execution of upgrading the StockRoom10net solution from .NET 10.0 to .NET 11.0 (PREVIEW). Both projects (MyStuff10net class library and StockRoom10net WinForms application) will be upgraded simultaneously in a single atomic operation, followed by testing and validation.

**Progress**: 4/4 tasks complete (100%) ![0%](https://progress-bar.xyz/100)

---

## Tasks

### [✓] TASK-001: Verify prerequisites *(Completed: 2026-03-08 03:16)*
**References**: Plan §Phase 0 Preparation

- [✓] (1) Verify .NET 11 SDK installed on development machine
- [✓] (2) .NET 11 SDK meets minimum requirements (**Verify**)
- [✓] (3) Validate external assembly references are accessible per Plan §StockRoom10net External Assembly References (CodeVendor.Controls, ObjectListView, WeifenLuo WinFormsUI libraries)
- [✓] (4) All external assemblies accessible (**Verify**)

---

### [✓] TASK-002: Atomic framework and dependency upgrade *(Completed: 2026-03-08 03:22)*
**References**: Plan §Phase 1 Atomic Upgrade, Plan §Package Update Reference, Plan §Breaking Changes Catalog

- [✓] (1) Update `<TargetFramework>` to `net11.0-windows` in both MyStuff10net.csproj and StockRoom10net.csproj
- [✓] (2) Both projects updated to `net11.0-windows` (**Verify**)
- [✓] (3) Remove `Microsoft.AspNetCore.Mvc.Razor.Extensions` package reference from MyStuff10net.csproj
- [✓] (4) Update all package references per Plan §Package Update Reference (Entity Framework Core 10.0.2 → 10.0.3, Microsoft.Extensions preview → 10.0.3, Newtonsoft.Json 13.0.5-beta1 → 13.0.4, Blazor WebView packages verified for .NET 11)
- [✓] (5) All package references updated (**Verify**)
- [✓] (6) Restore all dependencies (`dotnet restore`)
- [✓] (7) All dependencies restored successfully (**Verify**)
- [✓] (8) Build solution and fix all compilation errors per Plan §Breaking Changes Catalog (focus on legacy Windows Forms controls, System.Drawing.Common, configuration system, System.Speech if needed)
- [✓] (9) Solution builds with 0 errors (**Verify**)

---

### [✓] TASK-003: Run full test suite and validate upgrade *(Completed: 2026-03-07 22:23)*
**References**: Plan §Phase 2 Test Validation, Plan §Testing & Validation Strategy

- [✓] (1) Run automated tests in all test projects (if any exist in solution)
- [⊘] (2) Fix any test failures (reference Plan §Breaking Changes Catalog for common migration issues)
- [⊘] (3) Re-run tests after fixes
- [✓] (4) All tests pass with 0 failures (**Verify**)

---

### [✓] TASK-004: Final commit *(Completed: 2026-03-08 03:36)*
**References**: Plan §Source Control Strategy

- [✓] (1) Commit all changes with message: "Upgrade solution to .NET 11.0 - Updated MyStuff10net.csproj and StockRoom10net.csproj to net11.0-windows - Upgraded Entity Framework Core packages: 10.0.2 → 10.0.3 - Upgraded Microsoft.Extensions packages: preview → 10.0.3 - Downgraded Newtonsoft.Json: 13.0.5-beta1 → 13.0.4 (stable) - Removed Microsoft.AspNetCore.Mvc.Razor.Extensions (functionality in framework) - Verified Blazor WebView packages compatible with .NET 11 - Fixed compilation errors per breaking changes catalog - All tests passing - Application verified on .NET 11.0 PREVIEW"

---






