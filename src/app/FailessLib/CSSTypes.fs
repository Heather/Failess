[<AutoOpen>]
module Failess.CSSTypes

open System
open System.ComponentModel

type Clear =
    | Both
    override this.ToString() =
        match this with
        | Both -> "both"

type TextDecoration =
    | None
    override this.ToString() =
        match this with
        | None -> "none"

type TextAlign =
    | Center
    | Left
    | Right
    override this.ToString() =
        match this with
        | Center    -> "center"
        | Left      -> "left"
        | Right     -> "right"

type FontWeight =
    | Bold
    override this.ToString() =
        match this with
        | Bold -> "bold"

type FontVariant =
    | SmallCaps
    override this.ToString() =
        match this with
        | smallCaps -> "small-caps"

type WhiteSpace =
    | NoWrap
    override this.ToString() =
        match this with
        | NoWrap -> "nowrap"

type Border =
    | None
    | Solid
    override this.ToString() =
        match this with
        | None  -> "none"
        | Solid -> "solid"

type Position =
    | Relative
    override this.ToString() =
        match this with
        | Relative -> "relative"

type LineHeight =
    | Normal
    override this.ToString() =
        match this with
        | Normal -> "normal"

type ListStyle =
    | None
    override this.ToString() =
        match this with
        | None -> "none"

type Display =
    | Block
    | Inline
    override this.ToString() =
        match this with
        | Block -> "block"
        | Inline -> "inline"