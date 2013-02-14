[<AutoOpen>]
module Failess.CSSTypes

open System
open System.ComponentModel

type TextDecoration =
    | none = 0

type TextAlign =
    | center = 0

type WhiteSpace =
    | nowrap = 0

[<TypeConverter(typedefof<EnumToStringUsingDescription>)>]
type FontVariant =
    | [<Description("small-caps")>] smallCaps = 0

type Border =
    | solid = 0

type Position =
    | relative = 0

type LineHeight =
    | normal = 0

type ListStyle =
    | none = 0

type Display =
    | block = 0