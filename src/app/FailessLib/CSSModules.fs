[<AutoOpen>]
module Failess.CSSModules

module Border =
    let Set  w t c =
        border ---- [w; s t; c]

module Float =
    let Left = "float: left;"
    let Right = "float: right;"

module FontVariant =
    let internal (-) p = fontVariant -- p
    let SmallCaps = (-) "small-caps"

module FontWeight =
    let internal (-) p = fontWeight -- s p
    let Bold = (-) FontWeight.bold

module Display =
    let internal (-) p = display -- s p
    let Block = (-) Display.block
    let Inline = "display: inline;"

module TextAlign =
    let internal (-) p = textAlign -- s p
    let Center = (-) TextAlign.center
    let Left = (-) TextAlign.left
    let Right = (-)TextAlign.right

module Color =
    let White   = "color: White;"
    let Black   = "color: Black;"
    let Red     = "color: Red;"