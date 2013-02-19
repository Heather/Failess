@echo off

SET EnableNuGetPackageRestore=true
set MSBuild="%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"

pushd .
cd D:\...........\Failess\build\
set ABS_PATH=%CD%

:: site.css
"Failess.exe" "D:\.......\Site.fsx"
	
:: PropertyGrid
"Failess.exe" "D:\.......\PropertyGrid.fsx"
	
:: Settings.css
"Failess.exe" "D:\.........\Settings.fsx"

popd

pause
