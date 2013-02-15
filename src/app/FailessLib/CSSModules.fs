[<AutoOpen>]
module Failess.CSSModules

let internal (-) m p = m -- s p

module Border =
    let set  w t c =
        border ---- [w; s t; c]

module Float =
    let left = "float: left;"
    let right = "float: right;"

module FontVariant =
    let internal (-) p = (-) fontVariant p
    let SmallCaps = (-) FontVariant.SmallCaps

module FontWeight =
    let internal (-) p = fontWeight -- s p
    let bold = (-) FontWeight.Bold

module Display =
    let internal (-) p = (-) display p
    let block = (-) Display.Block
    let Inline = (-) Display.Inline

module TextAlign =
    let internal (-) p = (-) textAlign p
    let center = (-) TextAlign.Center
    let left = (-) TextAlign.Left
    let right = (-)TextAlign.Right

module Color =
    let white   = "color: white;"
    let black   = "color: black;"
    let red     = "color: red;"