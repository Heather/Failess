#I @"packages/Failess/tools/"
#I @"packages/Fuchu.0.3.0.1/lib/net40-client"

#r @"FakeLib.dll"
#r @"Gallio.dll"

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

(* Ideally should take result from build but don't know how *)
#r @"Fuchu.dll"
#r @"FailLib.dll"
#r @"FailessLib.dll"
module Tests =
    open Fuchu
    open Failess
    open FailessTestData
    open System.Text.RegularExpressions
    Target "FailLib Tests" (fun _ ->
        let convertTest = 
            testCase "CSSConvert Test" <| 
                fun _ -> 
                    Assert.Equal("ToFailess"
                        , Regex.Split( failess, "\n")
                        , Regex.Split(( toFailess 
                                        <| ( Array.toList  <| Regex.Split(css, "\n") )
                                           ), System.Environment.NewLine)
                        )
        run convertTest |> ignore
    )

Target "Success" (fun _ -> ())

open Tests

"Clean"
    ==> "RestorePackages"
    ==> "BuildSolution"
    ==> "F# 3.1"
    ==> "FailLib Tests"
    ==> "Success"

RunTargetOrDefault "Success"