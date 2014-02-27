#I @"packages/Failess/tools/"
#r @"FakeLib.dll"

open Fake
open System
open System.IO

let buildDir = "./build"
let nugetDir = "./packages"
let packagesDir = "./packages"

Target "Clean" (fun _ -> CleanDirs [buildDir])

Target "RestorePackages" RestorePackages

Target "BuildSolution" (fun _ ->
    MSBuildWithDefaults "Build" ["./Failess.sln"]
    |> Log "AppBuild-Output: "
)

open System.Diagnostics
Target "Test" (fun _ ->
    let shellExecute program args =
        let startInfo = new ProcessStartInfo()
        startInfo.FileName          <- program
        startInfo.Arguments         <- args
        startInfo.UseShellExecute   <- false
        let proc = Process.Start(startInfo)
        proc.WaitForExit()
    shellExecute <| if isLinux 
                        then @"mono" "build\FailTests.exe"
                        else @"build\FailTests.exe" ""
)

Target "Success" (fun _ -> ())

"BuildSolution" <== ["Clean"; "RestorePackages"]
"Test" <== ["BuildSolution"]

RunTargetOrDefault "Test"
