Failess FAKE integration
========================

Fake integration:
-----------------

``` fsharp
#r @"FakeLib.dll"
#r @"FailessLib.dll"

open Fake
open Failess

Target "Build" (fun () -> 
    trace " --- Building CSS --- "
    pasteNewLine <- false
    CSS [
        "/* DEFAULTS\n----------------------------------------------------------*/"
		@"/* up to date Failess example in library readme.md: 
			Cynede/FailessLib */"
        ])

"Build"; RunParameterTargetOrDefault "target" "Build"
```

to be honest:
-------------

The only thing this project does yet is displaying FailessLib version with Failess --version
NOTHING MORE here, check https://github.com/Cynede/FailessLib for more. 
