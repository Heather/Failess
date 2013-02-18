[<AutoOpen>]
module Failess.CSSCore
open System
open System.ComponentModel

let inline (+++) a b = sprintf "%s%s" a b
let inline (++) a b = sprintf "%s %s" a b

let inline s str = str.ToString()
