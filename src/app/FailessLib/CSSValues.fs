[<AutoOpen>]
module Failess.CSSValues

open System.Globalization

let nfi = new NumberFormatInfo()
nfi.NumberDecimalSeparator <- "."

let px v = s v +++ "px"
let pxx vv = [for v in vv -> px v]

let em (v : double) = v.ToString(nfi) +++ "em"
let emm vv = [for v in vv -> em v]

let pt v = s v +++ "pt"
let ptt vv = [for v in vv -> pt v]

let prc v = s v +++ "%"
let prcc vv = [for v in vv -> prc v]