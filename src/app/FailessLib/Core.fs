[<AutoOpen>]
module Failess.Core

open Fake

/// Run the given buildscript with fsi.exe
let runBuildScriptAt_ss workingDirectory printDetails script args =
    if printDetails then traceFAKE "Running Buildscript: %s" script
    let result = ExecProcess (fsiStartInfo script workingDirectory args) System.TimeSpan.MaxValue
    (System.Threading.Thread.Sleep 1000)
    result = 0

let runBuildScript_ss printDetails script args =
    runBuildScriptAt_ss "" printDetails script args