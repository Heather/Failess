[<AutoOpen>]
module Failess.CSSTypes

open System
open System.ComponentModel

type TextDecoration =
    | none = 0

[<TypeConverter(typedefof<EnumToStringUsingDescription>)>]
type FontVariant =
    | [<Description("small-caps")>] smallCaps = 0

type Border =
    | solid = 0