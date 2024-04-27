# HexPawnApi

An API to be used by my game concepts to create the game while not worrying about the UI / UX and getting the ball moving on creating the game from the back end.

### [CHANGELOG.md](Documentation%2FCHANGELOG.md)

version history of features and changes

### [DEVELOPMENTLOG.md](Documentation%2FDEVELOPMENTLOG.md)
    
log of dev tasks (optional by dev), to record the dev process


# Database Migrations

## run initial database migration

ran this script from the root directory

```bash
 dotnet ef migrations add InitialCreate --startup-project Hexpawn.Api --project HexPawn.Configuration  --output-dir "../HexPawn.Api/Migrations" --context ApplicationDbContext --json
```
