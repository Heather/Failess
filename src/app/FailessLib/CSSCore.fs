[<AutoOpen>]
module Failess.CSSCore
open System
open System.ComponentModel

let (+++) a b = sprintf "%s%s" a b
let (++) a b = sprintf "%s %s" a b

let s str = str.ToString()
