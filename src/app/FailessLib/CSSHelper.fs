[<AutoOpen>]
module Failess.CSS

open System
open Heather.Syntax

let tab = "    "

let (@) st = 
    match st with
    | [] -> ""
    | [ _ ] -> sprintf " { %s }" st.Head
    | _ -> 
        let pars = 
            [for s in st -> 
                sprintf "%s%s" 
                <| tab
                <| s]
        sprintf " {%s%s%s%s}" 
        <| System.Environment.NewLine
        <| String.Join(System.Environment.NewLine, pars)
        <| System.Environment.NewLine
        <| tab

let (-|) el st =
    sprintf "%s%s"
    <| el
    <| (@) st

let (=|) el st =
    match el with
        | [] -> ""
        | [ _ ] -> el.Head -| st
        | _ -> String.Join(", ", el) -| st

let (--) el st =
    sprintf "%s: %s;"
    <| el 
    <| st.ToString()

let (---) el st =
    sprintf "%s: %s;"
    <| el 
    <| String.Join(", ", (st : string list))

let (----) el st =
    sprintf "%s: %s;"
    <| el 
    <| String.Join(" ", (st : string list))

let (<%>) el p =
    sprintf "%s:%s" el p
let (%) a = sprintf ":%s" a
let (<^>) el p =
    sprintf "%s.%s" el p
let (^) a = sprintf ".%s" a
let (+) a = sprintf " %s" a

let (<+>) a b = sprintf "%s+%s" a b
let (*) el els =
    let fall = [for e : string in els ->
                    match e with
                    | e when e.Contains("+") -> 
                        let ells = e.Split('+')
                        String.Join(", ",
                            [for ell in ells ->
                                el +++ ell])
                    | _ -> el +++ e]
    String.Join(System.Environment.NewLine, fall)

let (<>>) a b = sprintf "%s > %s" a b
let (<<>) a b = sprintf "%s < %s" a b

let CSS triller =
    let css =   triller
                |> Seq.map /> fun str -> 
                    match pasteNewLine with
                    | false ->  s str
                    | true ->   sprintf "%s%s"
                                <| System.Environment.NewLine
                                <| s str
    System.IO.File.WriteAllLines(
        "stie.css", css);