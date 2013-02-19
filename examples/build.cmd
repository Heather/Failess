@echo off

pushd .
cd D:\...........\Failess\build\

:: site.css
"Failess.exe" "D:\.......\Site.fsx"
	
:: PropertyGrid
"Failess.exe" "D:\.......\PropertyGrid.fsx"
	
:: Settings.css
"Failess.exe" "D:\.........\Settings.fsx"

popd
