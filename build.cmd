@echo off

:: Environment
SET EnableNuGetPackageRestore=true
if %PROCESSOR_ARCHITECTURE%==x86 (
	set MSBuild="%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
) else (
	set MSBUILD=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe
)

:: Clear
rm -rf build
rm -rf tools

rm -rf FAKE/build
rm -rf FAKE/BuildMetrics
rm -rf FAKE/docs
rm -rf FAKE/nuget
rm -rf FAKE/Publish
rm -rf FAKE/report
rm -rf FAKE/test

rm -rf src/app/Failess/bin
rm -rf src/app/Failess/obj

rm -rf src/app/FailLib/bin
rm -rf src/app/FailLib/obj

rm -rf src/app/FailessLib/bin
rm -rf src/app/FailessLib/obj


:: Build
pushd .
cd ./FAKE
set ABS_PATH=%CD%
if not exist "%ABS_PATH%\tools\FAKE\tools\Fake.exe" (
	"%ABS_PATH%\tools\nuget\nuget.exe" "install" "FAKE" "-OutputDirectory" "tools" "-ExcludeVersion" "-Prerelease"
	)
"%ABS_PATH%\tools\FAKE\tools\Fake.exe" "build.fsx"
popd

%MSBuild% /p:Configuration=Release Failess.sln

cp "FAKE\lib\fsi\FSharp.Core.optdata" "build\FSharp.Core.optdata"
cp "FAKE\lib\fsi\FSharp.Core.sigdata" "build\FSharp.Core.sigdata"

echo build done
pause