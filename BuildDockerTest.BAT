@echo off
echo Building Docker test image...
docker build -t MyWorld-tests -f TestsDockerfile .

echo.
echo Running tests...
docker run --rm -v /var/run/docker.sock:/var/run/docker.sock MyWorld-tests

echo.
echo Extracting test results...
docker run --rm -v "%cd%/TestResults:/host" MyWorld-tests sh -c "cp -r /app/TestResults/* /host/ 2>/dev/null || echo 'No results to copy'"

echo.
echo Checking for test results...

if exist "%cd%\TestResults\TestResults.trx" (
    echo Test results found: %cd%\TestResults\TestResults.trx
    echo.
    echo Reading test results...
    powershell -Command "[xml]$xml = Get-Content '%cd%\TestResults\TestResults.trx'; $xml.TestRun.Results.UnitTestResult | Format-Table -Property testName, outcome, duration -AutoSize"
    echo.
    echo Opening test results directory...
    explorer "%cd%\TestResults"
) else (
    echo No test results file found at: %cd%\TestResults\TestResults.trx
)

echo Done.
pause
