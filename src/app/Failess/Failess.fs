﻿open System
open System.IO

open Fake

module CommandlineParams =
    let printAllParams() = printfn "Failess.exe [buildScript] [Target] Variable1=Value1 Variable2=Value2 ... "
    let parseArgs cmdArgs =
        let splitter = [|'='|]
        cmdArgs 
            |> Seq.skip 1
            |> Seq.mapi(fun (i:int) (arg:string) ->
                    if arg.Contains "=" then
                        let s = arg.Split splitter
                        if s.[0] = "logfile" then
                            addXmlListener s.[1]
                        s.[0], s.[1]
                    else
                        if i = 0 then
                            "Target", arg
                        else
                            arg, "")
            |> Seq.toList

let FakeInit() =
    let CcolorMap = function
        | ImportantMessage _ -> ConsoleColor.Blue
        | ErrorMessage _     -> ConsoleColor.Red
        | LogMessage _       -> ConsoleColor.DarkGray
        | TraceMessage _     -> ConsoleColor.DarkBlue
        | FinishedMessage    -> ConsoleColor.Black
        | _                  -> ConsoleColor.DarkGray

    let CConsoleTraceListener = ConsoleTraceListener(buildServer <> CCNet,CcolorMap)
    listeners.[0] <- CConsoleTraceListener

open Failess

let printVersion() =
    traceFAKE "Failess Version: %s" failessVersion
    traceFAKE "Failess Path: %s" fakePath
    traceFAKE "FakeLib Version: %s" fakeVersionStr


let printEnvironment cmdArgs args =
    printVersion()
    if buildServer = LocalBuild then
        trace localBuildLabel
    else
        tracefn "Build-Version: %s" buildVersion
    if cmdArgs |> Array.length > 1 then
        traceFAKE "Failess Arguments:"
        args 
          |> Seq.map fst
          |> Seq.iter (tracefn "%A")

    log ""
    traceFAKE "FSI-Path: %s" fsiPath
    traceFAKE "MSBuild-Path: %s" msBuildExe
let containsParam param = Seq.map toLower >> Seq.exists ((=) (toLower param))  
let buildScripts = !! "*.fsx" |> Seq.toList

try
    FakeInit()
    try            
        AutoCloseXmlWriter <- true            
        let cmdArgs = System.Environment.GetCommandLineArgs()                
        if containsParam "version" cmdArgs then printVersion() else
        if (cmdArgs.Length = 2 && cmdArgs.[1].ToLower() = "help") || (cmdArgs.Length = 1 && List.length buildScripts = 0) then CommandlineParams.printAllParams() else
        let buildScriptArg = if cmdArgs.Length > 1 && cmdArgs.[1].EndsWith ".fsx" then cmdArgs.[1] else Seq.head buildScripts
        let args = CommandlineParams.parseArgs (cmdArgs |> Seq.filter ((<>) buildScriptArg) |> Seq.filter ((<>) "details"))

        traceStartBuild()

        let printDetails = true // containsParam "details" cmdArgs      
        if printDetails then 
            printEnvironment cmdArgs args
        if not (runBuildScript printDetails buildScriptArg args) then
            Environment.ExitCode <- 1
        else
            if printDetails then log "Ready."
    with
    | exn -> 
        if exn.InnerException <> null then
            sprintf "Build failed.\nError:\n%O\nInnerException:\n%O" exn exn.InnerException
            |> traceError
        else
            sprintf "Build failed.\nError:\n%O" exn
            |> traceError
        sendTeamCityError exn.Message
        Environment.ExitCode <- 1

    if buildServer = BuildServer.TeamCity then
        killFSI()
        killMSBuild()
finally
    traceEndBuild()