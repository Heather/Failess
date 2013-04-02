Failess ( F# CSS EDSL. ) FAKE integration
=========================================

Fake integration:
-----------------

``` fsharp
#r @"FakeLib.dll"
#r @"FailessLib.dll"
open Fake
open Failess
Target "Build" (fun () -> 
    trace " --- Building CSS --- "
    pasteNewLine <- false
    CSS [
        ...
        ])
"Build"; RunParameterTargetOrDefault "target" "Build"
```

The only thing this project does yet is displaying FailessLib version with Failess --version
NOTHING MORE here, check https://github.com/Heather/FailessLib for more. 

CSS EDSL <embedded domain specific language> in F#
==================================================

Some features list (based on Clay) just to show why do I make it

 - Could be embedded in your application.
 - Highlighting as is F#.
 - Language sugar.
 - Making CSS relations with external things.
 - First class style properties.
 - First class selectors.
 - Typed values.
 - Nested style rules.
 - Access to outer scopes in nested rules.
 - Size and color arithmetics.
 - Recognizable syntax, inspired by CSS.
 - Easily extensible with new functionality.
 - Easy fall-back for uncovered parts.
 - Various options and styles.
 - Obfuscation

``` fsharp
open Failess

let Site style =
    pasteNewLine <- false
    obfuscation  <- true
    let menuStyle = [ 
        // Modules
        Display.block
        TextDecoration.none
        WhiteSpace.nowrap

        // Strings
        backgroundColor -- "#465c71"
        color           -- "#dde4ec"

        // Values
        lineHeight      -- em 1.35
        padding         -/ px2 4 20

        // Custom
        Border.set (px 1) Border.Solid "#4e667d"
        ]
    CSS "..\Styles\Site.css" [
        "/* DEFAULTS\n--------------------------------------------*/"
        body-|[
            background  -- "#b6b7bc"
            fontSize    -- em 0.80
            fontFamily  -+
                [   "Helvetica Neue"; 
                    "Lucida Grande"; 
                    "Segoe UI"; 
                    "Arial"; 
                    "Helvetica"; 
                    "Verdana"; 
                    "sans-serif";
                ] 
            ]
        a <<[
            %visited >< %link @ color -- "#034af3"
            %hover -| [ TextDecoration.none
                        color -- "#1d60ff"
                        ]
            ]
        p -|[
            marginBottom    -- px 10
            lineHeight      -- em 1.6
            ]
        "/* HEADINGS\n--------------------------------------------*/"
        [h1; h2; h3; h4; h5; h6] =| [ 
            FontVariant.smallCaps
            fontSize    -- em 1.5
            color       -- "#666666"
            ]
        h1-|[
            fontSize        -- em 1.6
            paddingBottom   -- px 0
            marginBottom    -- px 0
            ]
        h2-|[
            fontSize    -- em 1.5
            fontWeight  -- 600
            ]
        h3 @ fontSize -- em 1.2
        h4 @ fontSize -- em 1.1
        [h5; h6] @@ fontSize -- em 1.0
        "/* this rule styles <h1> and <h2> tags that are the \n first child of the left and right table %umns */"
        [   -."rightcolumn"  .> h1;
            -."rightcolumn"  .> h2;
            -."leftcolumn"   .> h1;
            -."leftcolumn"   .> h2] @@ marginTop -- px 0
        "/* PRIMARY LAYOUT ELEMENTS\n--------------------------------------------*/"
        -.page-|[
            width -- 
                match style with
                | styles.Full       -> prc 100
                | _                 -> px 960
            backgroundColor -- "#fff"
            margin -/
                match style with
                | styles.Full       -> px4 0 0 0 0
                | _                 -> [ px 20; auto; px 0; auto ]
            Border.set "1px" Border.Solid "#496077"
            ]
        -.header << [
            +.[ Position.relative
                margin      -- px 0
                padding     -- px 0
                width       -- prc 100
                background  -- "#4b6c9e"
                ]
            +h1 -| [
                border      -- Border.None
                cursor      -- Cursor.Default
                color       -- "#f9f9f9"
                fontWeight  -- 700
                margin      -- px 0
                lineHeight  -- em 2.0
                fontSize    -- em 2.0
                padding     -/ px4 0 0 0 10
                ]
            ]
        -.main-|[
            padding     -/ px2 0 12
            margin      -/ px4 12 8 8 8
            minHeight   -- px 420
            ]
        -."left"-|[
            padding     -/ px2 6 12
            margin      -/ px4 12 8 8 8
            width       -- px 200
            minHeight   -- px 200
            ]
        -.footer-|[
            TextAlign.center
            LineHeight.normal
      
            color       -- "#4e5766"

            padding     -/ px4 8 0 0 0
            margin      -/ [px 0; auto]
            ]
        "/* TAB MENU\n--------------------------------------------*/"
        div << [
            -."hideSkiplink"-|[
                backgroundColor -- "#3a4f63"
                width -- prc 100
                ]
            -."accountInfo" @ width -- prc 42
            -.menu << [
                +.[padding -/ px4 4 0 4 8]
                +ul << [
                    +.[
                        listStyle   -- ListStyle.None
                        margin      -- px 0
                        padding     -- px 0
                        width       -- auto
                        ]
                    +li ++ a << [
                        +.menuStyle
                        %visited -| menuStyle
                        %hover-|[
                            backgroundColor -- "#bfcbd6"
                            color           -- "#465c71"
                            textDecoration  -- TextDecoration.None
                            ]
                        %active-|[
                            backgroundColor -- "#465c71"
                            color           -- "#cfdbe6"
                            textDecoration  -- TextDecoration.None
                            ]
                        ]
                    ]
                ]
            ]
        "/* FORM ELEMENTS\n--------------------------------------------*/"
        "fieldset" << [
            +. [    margin -/ [em 1.0; px 0]
                    padding -- em 1.0
                    Border.set <| px 1 <| Border.Solid <| "#ccc"
                ]
            +p @ margin -/ px4 2 12 10 10
            -."login" -. "inline" @ display -- Display.Inline
            -."login" ++ label 
                >< -. "register" ++ label 
                >< -. "changePassword" ++ label 
                    @ Display.block
            ]
        "legend"-|[
            fontSize    -- em 1.1
            fontWeight  -- 600
            padding     -/ px4 2 4 8 4
            ]

        Border.set "1px" Border.Solid "#ccc" 
        |> fun borderForInput ->
            input << [
                -."textEntry "-|[
                    borderForInput
                    width -- px 320
                    ]
                -."passwordEntry"-|[
                    borderForInput
                    width -- px 320
                    ]
                ]
        "/* MISC\n--------------------------------------------*/"
        -.clear @ Clear.both
        -.title  -|[
            Display.block
            Float.left
            ]

        -."loginDisplay" << [
            +. [fontSize       -- em 1.1
                padding        -- px 10
                Display.block
                TextAlign.right
                Color.white
                ]
            +a << [
                %link     @ Color.white
                %visited  @ Color.white
                %hover    @ Color.white
                ]
            ]

        -."bold" @ FontWeight.bold

        -."failureNotification"  -|[    Color.red
                                        fontSize -- em 1.2
                                    ]
        -."submitButton"         -|[    TextAlign.right
                                        paddingRight -- px 10
                                    ]
        ]

```

