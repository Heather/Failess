#r @"FakeLib.dll"
#r @"FailessLib.dll"
#r @"Heather.dll"

open Fake
open Failess

Description "Cleans the last build"
Target "Clean" (fun () -> 
    trace " --- Cleaning stuff --- "
    //rm -rf *.css
    )

Target "Build" (fun () -> 
    trace " --- Building Failess --- "
    try
        CSS
            [
            body -| 
                [
                background |- "#b6b7bc";
                fontSize |- ".80em";
                ];
            [a%link; a%visited]
                =| [ color |- "#034af3" ];
            ]
    with | _ as exc ->
        trace (" --- Failed to build: " + exc.Message)
    )

"Clean"
  ==> "Build"

RunParameterTargetOrDefault "target" "Build"
