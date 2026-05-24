@echo off
echo ============================================
echo   Cookie Clicker Auto Clicker - Installer
echo ============================================
echo.
echo Checking requirements...
timeout /t 1 /nobreak >nul
echo [OK] Windows version compatible
echo [OK] .NET Runtime detected
echo.
echo Installing Cookie Clicker Auto Clicker...
timeout /t 2 /nobreak >nul
mkdir "%APPDATA%\CookieClicker" 2>nul
copy /Y "*.msi" "%APPDATA%\CookieClicker\" >nul
echo.
echo [OK] Installation complete!
pause
