﻿[<AutoOpen>]
module Fail.FSIHelper

open Fake

open System.Linq
open System.Diagnostics

/// The Path to the F# interactive tool
let mutable myFsiPath = 
    let ev = environVar "FSI"
    if not (isNullOrEmpty ev) then ev else 
    if isUnix then
        let paths = appSettings "FSIPath"
        // The standard name on *nix is "fsharpi"
        match tryFindFile paths "fsharpi" with
        | Some file -> file
        | None -> 
        // The early F# 2.0 name on *nix was "fsi"
        match tryFindFile paths "fsi" with
        | Some file -> file
        | None -> "fsharpi" 
    else
        let dir = System.IO.Path.GetDirectoryName fullAssemblyPath
        let fi = fileInfo (System.IO.Path.Combine(dir,"fsi.exe"))
        if fi.Exists then fi.FullName else
        findPath "FSIPath" "fsi.exe"

let myFsiStartInfo script workingDirectory args = 
    (fun (info : ProcessStartInfo) ->  
        info.FileName <- myFsiPath
        info.Arguments <- script
        info.WorkingDirectory <- workingDirectory
        
            
        let setVar (k,v) =
            if info.EnvironmentVariables.ContainsKey k then
                info.EnvironmentVariables.[k] <- v
            else 
                info.EnvironmentVariables.Add(k,v)

        args |> Seq.iter setVar

        setVar("MSBuild",msBuildExe)
        setVar("GIT",Git.CommandHelper.gitPath)
        setVar("FSI",myFsiPath))
      
/// Run the given buildscript with fsi.exe
let myExecuteFSI workingDirectory script args =
   
    let (result, messages) = 
        ExecProcessRedirected  
            (myFsiStartInfo script workingDirectory args)
            System.TimeSpan.MaxValue
    
    System.Threading.Thread.Sleep 1000
    (result, messages)

/// Run the given buildscript with fsi.exe
let myRunBuildScriptAt workingDirectory printDetails script args =
    if printDetails then traceFAKE "Running Buildscript: %s" script
    let result = ExecProcess (myFsiStartInfo script workingDirectory args) System.TimeSpan.MaxValue
    (System.Threading.Thread.Sleep 1000)
    result = 0

let go printDetails script args =
    myRunBuildScriptAt "" printDetails script args