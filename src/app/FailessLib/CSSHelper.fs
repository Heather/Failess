[<AutoOpen>]
module Failess.CSS

open System
open Heather.Syntax

let tab = "    "

let (-|) el st =
    match st with
    | [] -> ""
    | [ _ ] -> sprintf "%s { %s }" el st.Head
    | _ -> 
        let pars = 
            [for s in st -> 
                sprintf "%s%s" 
                <| tab
                <| s]
        sprintf "%s {%s%s%s%s}" 
        <| el 
        <| System.Environment.NewLine
        <| String.Join(System.Environment.NewLine, pars)
        <| System.Environment.NewLine
        <| tab

let (=|) el st =
    match el with
        | [] -> ""
        | [ _ ] -> el.Head -| st
        | _ -> String.Join(", ", el) -| st

let (|-) el st =
    sprintf "%s: %s;" el st

let (%) el p =
    sprintf "%s:%s" el p

let CSS triller =
    let css =   triller
                |> Seq.map /> fun s -> 
                    sprintf "%s%s"
                    <| System.Environment.NewLine
                    <| s.ToString()
    System.IO.File.WriteAllLines(
        "stie.css", css);