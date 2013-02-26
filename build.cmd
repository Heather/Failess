@echo off

SET EnableNuGetPackageRestore=true
if %PROCESSOR_ARCHITECTURE%==x86 (
	set MSBuild="%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
) else (
	set MSBUILD=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe
)

pushd .
cd ./FAKE
set ABS_PATH=%CD%
if not exist "%ABS_PATH%\tools\FAKE\tools\Fake.exe" (
	"%ABS_PATH%\tools\nuget\nuget.exe" "install" "FAKE" "-OutputDirectory" "tools" "-ExcludeVersion" "-Prerelease"
	)
"%ABS_PATH%\tools\FAKE\tools\Fake.exe" "build.fsx"
popd

%MSBuild% src\app\Failess\Failess.fsproj /p:Configuration=Release

cp "FAKE\lib\fsi\FSharp.Core.optdata" "build\FSharp.Core.optdata"
cp "FAKE\lib\fsi\FSharp.Core.sigdata" "build\FSharp.Core.sigdata"

echo build done
pause