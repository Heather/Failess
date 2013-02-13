@echo off

SET EnableNuGetPackageRestore=true
set MSBuild="%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"

pushd .
cd ./FAKE
set ABS_PATH=%CD%
if not exist "%ABS_PATH%\tools\FAKE\tools\Fake.exe" (
	"%ABS_PATH%\tools\nuget\nuget.exe" "install" "FAKE" "-OutputDirectory" "tools" "-ExcludeVersion" "-Prerelease"
	)
"%ABS_PATH%\tools\FAKE\tools\Fake.exe" "build.fsx"
popd

pushd .
cd ./Heather 
set ABS_PATH=%CD%
if not exist "%ABS_PATH%\Heather.dll" (
	%MSBuild% %ABS_PATH%\src\Heather.fsproj /p:Configuration=Release
	cp %ABS_PATH%\src\bin\Release\Heather.dll "Heather.dll"
	)
"%ABS_PATH%\..\FAKE\tools\FAKE\tools\Fake.exe" build.fsx
cp %ABS_PATH%\src\bin\Release\Heather.dll "Heather.dll"
popd

%MSBuild% src\app\Failess\Failess.fsproj /p:Configuration=Release

cp "FAKE\lib\fsi\FSharp.Core.optdata" "build\FSharp.Core.optdata"
cp "FAKE\lib\fsi\FSharp.Core.sigdata" "build\FSharp.Core.sigdata"

echo build done
pause