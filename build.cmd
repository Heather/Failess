@echo off
::Env
if %PROCESSOR_ARCHITECTURE%==x86 (
	set MSBuild="%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
) else (
	set MSBUILD=%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe
)

cls
SET EnableNuGetPackageRestore=true

if not exist "tools\FAKE\tools\Fake.exe" (
	"tools\nuget\nuget.exe" "install" "FAKE" "-OutputDirectory" "tools" "-ExcludeVersion" "-Prerelease"
	)

::Clean
rm -rf build
mkdir build
    
::Build
%MSBuild% Failess.sln  /p:Configuration=Release

::F# 3.1
XCOPY /e "%ProgramFiles%\Reference Assemblies\Microsoft\FSharp\.NETFramework\v4.0\4.3.0.0\FSharp.Core.dll" "build"

pause