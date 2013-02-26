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
			" + url( https://github.com/Cynede/FailessLib ) + " */"
        ])

"Build"; RunParameterTargetOrDefault "target" "Build"
```
