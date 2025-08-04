@echo off
echo Adding Entity Framework Core migration...
dotnet ef migrations add nullableBase --project MyWorld.Infra --startup-project MyWorld.API

echo Done.
pause