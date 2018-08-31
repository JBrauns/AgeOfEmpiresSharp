@echo off

IF NOT EXIST ..\build mkdir ..\build
pushd ..\build
csc -nologo -main:Win32API.Win32Program -target:exe -recurse:..\src\*.cs -debug -fullpaths
popd

REM ..\build\win32_aoe_sharp.exe
