@echo off

cls
SET EnableNuGetPackageRestore=true

:: Get FAKE
pushd .
cd ./FAKE
set ABS_PATH=%CD%
if not exist "%ABS_PATH%\tools\FAKE\tools\Fake.exe" (
	"%ABS_PATH%\tools\nuget\nuget.exe" "install" "FAKE" "-OutputDirectory" "tools" "-ExcludeVersion" "-Prerelease"
	)
"%ABS_PATH%\tools\FAKE\tools\Fake.exe" "build.fsx"
popd

::F# Unicode
if not exist "tools\Heather\tools\net40\fsc.exe" (
    echo Getting Custom F# Compiler with Unicode Support
    "FAKE\tools\nuget\nuget.exe" "install" "Heather" "-OutputDirectory" "tools" "-ExcludeVersion"
)

::Failess - FAKE with custom FSI Support and CSS EDSL Library attached
if not exist "tools\Failess\tools\Failess.exe" (
    echo Getting Failess build tool with CSS EDSL library
    "FAKE\tools\nuget\nuget.exe" "install" "Failess" "-OutputDirectory" "tools" "-ExcludeVersion"
)

::Env
set c=tools\Heather\tools\net40\
set f=tools\Failess\tools\

%f%Failess.exe FSI=%c%fsi.exe Build.fsx

pause