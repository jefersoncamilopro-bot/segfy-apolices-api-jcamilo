@echo off

REM Vai para a pasta onde o BAT está
cd /d "%~dp0"

title Segfy HandsOn - Demo

echo =============================================
echo         SEGFY HANDS ON
echo =============================================
echo.

echo Pasta do projeto:
echo %CD%
echo.

echo [1/4] Restaurando pacotes...
dotnet restore

if errorlevel 1 (
    echo ERRO AO RESTAURAR PACOTES
    pause
    exit /b
)

echo.
echo [2/4] Compilando...
dotnet build Segfy.HandsOn.slnx

if errorlevel 1 (
    echo ERRO DE COMPILACAO
    pause
    exit /b
)

echo.
echo [3/4] Iniciando API...

start "Segfy API" cmd /k "cd /d ""%~dp0"" && dotnet run --project Segfy.Api"

timeout /t 8 /nobreak > nul

echo.
echo [4/4] Abrindo navegador...

start http://localhost:5028
start http://localhost:5028/swagger

echo.
echo Sistema iniciado com sucesso.
pause
pause