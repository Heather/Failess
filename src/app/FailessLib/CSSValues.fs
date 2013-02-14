[<AutoOpen>]
module Failess.CSSValues

open System.Globalization

let nfi = new NumberFormatInfo()
nfi.NumberDecimalSeparator <- "."

let px v = v.ToString() +++ "px"
let em (v : double) = v.ToString(nfi) +++ "em"