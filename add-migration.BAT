@echo off
echo Adding Entity Framework Core migration...
dotnet ef migrations add InitialCreate1 --project MyWorld.Infra --startup-project MyWorld.API

echo Done.
pause