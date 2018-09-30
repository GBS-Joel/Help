"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" ".\HelpSoftware\Help\Help.sln"
@echo off
IF %ERRORLEVEL% NEQ 0 EXIT /B 1
IF %ERRORLEVEL% EQU 0 EXIT /B 0