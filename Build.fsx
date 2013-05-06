#I @"tools\Failess\tools"
#r @"FakeLib.dll"
#r @"FailessLib.dll"
open Fake
open Failess

let inline (/>) f a = f a

open System
open System.IO

let buildDir = @"./build"

Target "Clean" /> fun () -> 
    let src = "src"
    let app = "app"
    let bin = "bin"
    let obj = "obj"
    
    let Failess     = "Failess"
    let FailLib     = "FailLib"
    let FailessLib  = "FailessLib"
    
    let (/) s1 s2 = sprintf "%s/%s" s1 s2
    
    CleanDirs ["build"]
    CleanDirs [src/app/Failess/bin; src/app/Failess/obj]
    CleanDirs [src/app/FailLib/bin; src/app/FailLib/obj]
    CleanDirs [src/app/FailessLib/bin; src/app/FailessLib/obj]
    
Target "Failess" /> fun () ->  
    MSBuildWithDefaults "Build" ["./Failess.sln"]
    |> Log "Failess Build-Output: "
    
Target "Fin" /> fun () ->  
    [@"./FAKE\lib\fsi\FSharp.Core.optdata"
     @"./FAKE\lib\fsi\FSharp.Core.sigdata"]
       |> CopyTo buildDir

"Clean" 
    ==> "Failess"
    ==> "Fin"

RunTargetOrDefault "Fin"