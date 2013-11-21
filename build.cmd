@echo off
cls
SET EnableNuGetPackageRestore=true

if not exist "packages\Failess\tools\Failess.exe" (
	"packages\nuget\nuget.exe" "install" "Failess" "-OutputDirectory" "packages" "-ExcludeVersion" "-Prerelease"
	)

"packages\Failess\tools\Failess.exe" "build.fsx"

::Show output
pause