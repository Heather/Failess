[<AutoOpen>]
module Failess.CSSValues

open System.Globalization

let nfi = new NumberFormatInfo()
nfi.NumberDecimalSeparator <- "."

let px v = s v +++ "px"
let em (v : double) = v.ToString(nfi) +++ "em"
let prc v = s v +++ "%"