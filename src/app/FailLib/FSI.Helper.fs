﻿[<AutoOpen>]
module Fail.FSIHelper

open Fake

open System
open System.IO
open System.Linq
open System.Diagnostics
open System.Threading

/// The path to the F# Interactive tool.
let mutable myFsiPath =
    let ev = environVar "FSI"
    if not (isNullOrEmpty ev) then ev else
    if isUnix then
        let paths = appSettings "fsiPath"
        // The standard name on *nix is "fsharpi"
        match tryFindFile paths "fsharpi" with
        | Some file -> file
        | None -> 
        // The early F# 2.0 name on *nix was "fsi"
        match tryFindFile paths "fsi" with
        | Some file -> file
        | None -> "fsharpi"
    else
        let dir = Path.GetDirectoryName fullAssemblyPath
        let fi = fileInfo (Path.Combine(dir, "fsi.exe"))
        if fi.Exists then fi.FullName else
        findPath "fsiPath" "fsi.exe"

let private FsiStartInfo script workingDirectory extraFsiArgs args =
    (fun (info: ProcessStartInfo) ->
        info.FileName <- myFsiPath
        info.Arguments <- String.concat " " (extraFsiArgs @ [script])
        info.WorkingDirectory <- workingDirectory
        let setVar k v =
            info.EnvironmentVariables.[k] <- v
        for (k, v) in args do
            setVar k v
        setVar "MSBuild"  msBuildExe
        setVar "GIT" Git.CommandHelper.gitPath
        setVar "FSI" myFsiPath)

/// Creates a ProcessStartInfo which is configured to the F# Interactive.
let fsiStartInfo script workingDirectory args =
    FsiStartInfo script workingDirectory [] args

/// Run the given buildscript with fsi.exe
let executeFSI workingDirectory script args =
    let (result, messages) =
        ExecProcessRedirected
            (fsiStartInfo script workingDirectory args)
            TimeSpan.MaxValue
    Thread.Sleep 1000
    (result, messages)

/// Run the given build script with fsi.exe and allows for extra arguments to FSI.
let executeFSIWithArgs workingDirectory script extraFsiArgs args =
    let result = ExecProcess (FsiStartInfo script workingDirectory extraFsiArgs args) TimeSpan.MaxValue
    Thread.Sleep 1000
    result = 0

/// Run the given buildscript with fsi.exe at the given working directory.
let runBuildScriptAt workingDirectory printDetails script args =
    if printDetails then traceFAKE "Running Buildscript: %s" script
    let result = ExecProcess (fsiStartInfo script workingDirectory args) System.TimeSpan.MaxValue
    Thread.Sleep 1000
    result = 0

/// Run the given buildscript with fsi.exe
let runBuildScript printDetails script args =
    runBuildScriptAt "" printDetails script args
