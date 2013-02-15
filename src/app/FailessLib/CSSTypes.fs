[<AutoOpen>]
module Failess.CSSTypes
open System
open System.ComponentModel
type Border =
    | None
    | Solid
    override this.ToString() =
        match this with
        | None  -> "none"
        | Solid -> "solid"
type Clear =
    | Both
    override this.ToString() =
        match this with
        | Both -> "both"
type Display =
    | Block
    | Inline
    override this.ToString() =
        match this with
        | Block -> "block"
        | Inline -> "inline"
type Float =
    | Left
    | Right
    override this.ToString() =
        match this with
        | Left -> "left"
        | Right -> "right"
type FontVariant =
    | SmallCaps
    override this.ToString() =
        match this with
        | smallCaps -> "small-caps"
type FontWeight =
    | Bold
    override this.ToString() =
        match this with
        | Bold -> "bold"
type ListStyle =
    | None
    override this.ToString() =
        match this with
        | None -> "none"
type LineHeight =
    | Normal
    override this.ToString() =
        match this with
        | Normal -> "normal"
type Position =
    | Relative
    override this.ToString() =
        match this with
        | Relative -> "relative"
type TextAlign =
    | Center
    | Left
    | Right
    override this.ToString() =
        match this with
        | Center    -> "center"
        | Left      -> "left"
        | Right     -> "right"
type TextDecoration =
    | None
    override this.ToString() =
        match this with
        | None -> "none"
type WhiteSpace =
    | NoWrap
    override this.ToString() =
        match this with
        | NoWrap -> "nowrap"
