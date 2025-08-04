@echo off
echo Building Docker application image...
docker build -t template-app .

echo.
echo Running application...
docker run --rm ^
  -p 8080:8080 ^
  -p 8081:8081 ^
  -e ASPNETCORE_ENVIRONMENT=Development ^
  -e ASPNETCORE_URLS=http://+:8080 ^
  -v "%cd%/logs:/app/logs" ^
  template-app

echo Done.
pause