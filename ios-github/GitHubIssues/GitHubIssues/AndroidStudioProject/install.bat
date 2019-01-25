@echo off
   rem ***********************************************************************
   rem This bat file creates symbolic links between Xamarin.Android Resources
   rem the Android Studio project resources, so one can edit the resources in
   rem the Studio.
   rem ***********************************************************************
@echo on

set res=%~dp0..\Resources\

set tar=%~dp0app\src\main\res\

for /F "delims=" %%i in ('dir "%tar%" /b') do (rmdir "%tar%%%i" /q)

cd /D "%res%"

for /D %%i in (*) do (mklink /J "%tar%%%i" "%res%%%i")