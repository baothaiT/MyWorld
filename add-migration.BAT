@echo off
echo Adding Entity Framework Core migration...
dotnet ef migrations add InitialCreate1 --project Template.Infra --startup-project Template.API

echo Done.
pause