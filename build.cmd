@echo off
cls
SET EnableNuGetPackageRestore=true

if not exist "packages\FAKE\tools\Fake.exe" (
	"packages\nuget\nuget.exe" "install" "FAKE" "-OutputDirectory" "packages" "-ExcludeVersion" "-Prerelease"
	)

"packages\FAKE\tools\Fake.exe" "build.fsx"

::Show output
pause