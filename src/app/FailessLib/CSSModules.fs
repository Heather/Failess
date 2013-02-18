﻿[<AutoOpen>]
module Failess.CSSModules
let inline internal (-) m p = m -- s p
module Border =
    let inline internal (-) p = (-) border p
    let none    = (-) Border.None
    let solid   = (-) Border.Solid
    let set  w t c =
        border ---- [w; s t; c]
module Cursor =
    let inline internal (-) p = (-) cursor p
    let pointer = (-) Cursor.Pointer
module Color =
    let white   = "color: white;"
    let black   = "color: black;"
    let red     = "color: red;"
module Display =
    let inline internal (-) p = (-) display p
    let block = (-) Display.Block
    let Inline = (-) Display.Inline
module Float =
    let inline internal (-) p = (-) "float" p
    let left = (-) Float.Left
    let right = (-) Float.Right
module FontVariant =
    let inline internal (-) p = (-) fontVariant p
    let smallCaps = (-) FontVariant.SmallCaps
module FontWeight =
    let inline internal (-) p = fontWeight -- s p
    let bold = (-) FontWeight.Bold
module TextAlign =
    let inline internal (-) p = (-) textAlign p
    let center = (-) TextAlign.Center
    let left = (-) TextAlign.Left
    let right = (-)TextAlign.Right
module TextDecoration =
    let inline internal (-) p = (-) textDecoration p
    let none = (-) TextDecoration.None
