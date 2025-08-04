@echo off
echo Removing Entity Framework Core migration...
dotnet ef migrations remove --project Template.Infra --startup-project Template.API

echo Done.
pause