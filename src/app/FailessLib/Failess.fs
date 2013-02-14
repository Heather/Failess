[<AutoOpen>]
module Failess.Console

open System
open Fake

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

let printVersion() =
    traceFAKE "Failess Version: 0.0.1"
    traceFAKE "Failess Path: %s" fakePath
    traceFAKE "FakeLib Version: %s" fakeVersionStr

let mutable pasteNewLine = false