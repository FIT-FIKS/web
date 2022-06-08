# Architecture

- `/Program.cs` - base settings
- `/appsettings.*.json` - connection strings, settings
- `/Data/` - wrapper classes for database access
- `/Migrations/` - migrations scripts for database changes
- `/Models/` - classes describing models (= database tables)
- `/Logic/` - all backend logic (such as task correction execution, calculations, ...)
- `/Pages/` - structured set of frontend views and basic frontend-related logic (such as validation)
