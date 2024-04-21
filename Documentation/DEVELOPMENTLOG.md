
# Notes on Install and Setup Steps:

## v0.0.1

- created .gitignore
- created .editorconfig
- created HexPawn.Api & HexPawn.sln
- settings > Editor > General
    - On Save: Select all options and Change to all lines
- remove weatherforecast from api
- Add empty project for xunit
- Add empty project for services
- Add empty project for models
- Add empty project for data
- Add empty project for configuration
- Add npgsql and entity framework to .data
- Add configuration custom dbcontext
- Install Postgres locally
- create empty db named localDb with the password admin like below
- "Server=localhost;Port=5432;Database=localDb;Userid=postgres;Password=admin;"
- refactor configuration to take in either appsettings or usersecrets and be more generic
- adding base entity repository

# Database Migrations

## run initial database migration 

ran this script from the root directory

```bash
dotnet ef migrations add InitialCreate --startup-project Hexpawn.Api --project HexPawn.Configuration --context ApplicationDbContext --json
```
