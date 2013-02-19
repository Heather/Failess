[<AutoOpen>]
module Failess.CSS

open System
open System.Text.RegularExpressions
open Heather

(* if you want to use different tab size *)
let mutable tab = "    "

let inline (~-) st = 
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

(*Note: This is main operators and they could look better
  Though it's easy to overrid by something alike:
    let inline (/) el st = el -| st
  There are some examples doing this*)
let inline (@) el st =
    sprintf "%s { %s }" el st
let inline (-|) el st =
    sprintf "%s%s"
    <| el
    <| - st
let inline (@@) el st =
    match el with
        | [] -> ""
        | [ _ ] -> el.Head @ st
        | _ -> String.Join(", ", el) @ st
let inline (=|) el st =
    match el with
        | [] -> ""
        | [ _ ] -> el.Head -| st
        | _ -> String.Join(", ", el) -| st
let inline (--) el st =
    sprintf "%s: %s;"
    <| el 
    <| st.ToString()
let inline (---) el st =
    sprintf "%s: %s;"
    <| el 
    <| String.Join(" ", (st : string list))
let inline (----) el st =
    sprintf "%s: %s;"
    <| el 
    <| String.Join(", ", (st : string list))

let inline (%) el p =
    sprintf "%s:%s" el p
let inline (~%) a = sprintf ":%s" a

(* override here T_T *)
let inline (&) el p =
    sprintf "%s.%s" el p
let inline (~&) a = sprintf ".%s" a

(* this is confusing stuff must be deprecated  or replaced *)
let inline (~+) a = sprintf " %s" a

let inline ($) a b = sprintf "%s, %s" a b

(* . operators *)
let inline (.>) a b = sprintf "%s > %s" a b
let inline (.<) a b = sprintf "%s < %s" a b

let inline (><) a b = sprintf "%s*%s" a b (*Weird hack*)
let inline (*) el els =
    let tree str = 
        let lines =
            [for line in Regex.Split(str, "\r\n") ->
                match line with 
                | line when line.StartsWith(tab) -> line
                | _ -> el +++ line]
        String.Join(System.Environment.NewLine, lines)
    let fall = [for e : string in els ->
                    match e with
                    | e when e.Contains("*") -> 
                        let ells = e.Split('*')
                        String.Join(", ",
                            [for ell in ells ->
                                tree ell])
                    | _ -> tree e]
    String.Join(System.Environment.NewLine, fall)

let CSS file triller =
    let css =   triller
                |> Seq.map /> fun str -> 
                    match pasteNewLine with
                    | false ->  s str
                    | true ->   sprintf "%s%s"
                                <| System.Environment.NewLine
                                <| s str
    System.IO.File.WriteAllLines(
        file, css);

let CSSSite triller = CSS "stie.css" triller