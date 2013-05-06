@echo off

cls
SET EnableNuGetPackageRestore=true

::F# Unicode
if not exist "tools\Heather\tools\fsc.exe" (
    echo Getting Custom F# Compiler with Unicode Support
    "FAKE\tools\nuget\nuget.exe" "install" "Heather" "-OutputDirectory" "tools" "-ExcludeVersion"
)

::Failess - FAKE with custom FSI Support and CSS EDSL Library attached
if not exist "tools\Failess\tools\Failess.exe" (
    echo Getting Failess build tool with CSS EDSL library
    "FAKE\tools\nuget\nuget.exe" "install" "Failess" "-OutputDirectory" "tools" "-ExcludeVersion"
)

::Env
set c=tools\Heather\tools\
set f=tools\Failess\tools\

%f%Failess.exe FSI=%c%fsi.exe Failess.fsx

pause