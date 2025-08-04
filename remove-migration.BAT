@echo off
echo Removing Entity Framework Core migration...
dotnet ef migrations remove --project MyWorld.Infra --startup-project MyWorld.API

echo Done.
pause