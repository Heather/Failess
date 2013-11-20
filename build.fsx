#I @"packages/FAKE/tools/"
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

Target "F# 3.1" (fun _ -> 
    let programFiles = 
        if (IntPtr.Size = 4)
            then Environment.GetEnvironmentVariable("ProgramFiles")
            else Environment.GetEnvironmentVariable("ProgramFiles(x86)")
    (* Moving from F# 3.0 to F# 3.1 is hard... *)
    sprintf @"%s\Reference Assemblies\Microsoft\FSharp\.NETFramework\v4.0\4.3.0.0\FSharp.Core.dll" programFiles
    |> fun newCore -> if File.Exists newCore then 
                        trace "-* Replacing 3.0 FSharp.Core.dll with 3.1 one\n"
                        File.Copy(newCore, "build\FSharp.Core.dll", true)
)

Target "FailLib Tests" (fun _ -> 
    trace "TODO: run fuchu tests from FAKE"
)

Target "Success" (fun _ -> ())

"Clean"
    ==> "RestorePackages"
    ==> "BuildSolution"
    ==> "F# 3.1"
    ==> "FailLib Tests"
    ==> "Success"

RunTargetOrDefault "Success"