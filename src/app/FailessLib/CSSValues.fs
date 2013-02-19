[<AutoOpen>]
module Failess.CSSValues
open System.Globalization

let nfi = new NumberFormatInfo()
nfi.NumberDecimalSeparator <- "."

let inline em (v : double) = v.ToString(nfi) +++ "em"
let inline emm vv = [for v in vv -> em v]

let inline prc v = s v +++ "%"
let inline prcc vv = [for v in vv -> prc v]

let inline pt v = s v +++ "pt"
let inline ptt vv = [for v in vv -> pt v]

let inline px v = s v +++ "px"
let inline pxx vv = [for v in vv -> px v]

let inline rgb(r,g,b) = sprintf "rgb(%d, %d, %d)" r g b
let inline url(u) = sprintf "url(%s)" u