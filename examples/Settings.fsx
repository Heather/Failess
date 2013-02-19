#I @"D:\....\Failess\build"
#r @"FakeLib.dll"
#r @"FailessLib.dll"
#r @"Heather.dll"

open Fake
open Failess
open Heather

Target "Build" /> fun () -> 
    trace " --- Building CSS --- "
    pasteNewLine <- false
    
    let mleft=".mleft"
    let mright=".mright"
    
    CSS "D:\....\Settings.css" [
        "/* DEFAULTS\n--------------------------------------------*/"
        mleft $ mright -|[ 
            width       -- prc 49
            minHeight   -- px 500
            border      --- [
                px 1
                s Border.Solid
                rgb(33, 33, 33)
                ]
            ]
        mleft @ Float.left
        mright @ Float.right
        ]

"Build"; RunParameterTargetOrDefault "target" "Build"