@echo off
cls
SET EnableNuGetPackageRestore=true

::if not exist "packages\Heather\tools\net40\Fsi.exe" (
::	"packages\nuget\nuget.exe" "install" "Heather" "-OutputDirectory" "packages" "-ExcludeVersion" "-Prerelease"
::	)
if not exist "packages\Failess\tools\Failess.exe" (
	"packages\nuget\nuget.exe" "install" "Failess" "-OutputDirectory" "packages" "-ExcludeVersion" "-Prerelease"
	)

::"packages\Failess\tools\Failess.exe" FSI="packages\Heather\tools\net40\Fsi.exe" "build.fsx"
"packages\Failess\tools\Failess.exe" "build.fsx"

::Show output
pause