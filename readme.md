Failess
=======

``` fsharp
#r @"FakeLib.dll"
#r @"FailessLib.dll"
#r @"Heather.dll"

open Fake
open Failess
open Heather

Target "Build" /> fun () -> 
    trace " --- Building CSS --- "
    pasteNewLine <- false
    CSS [
        "/* DEFAULTS\n----------------------------------------------------------*/"
        body-|[
            background -- "#b6b7bc"
            fontSize -- em 0.80
            fontFamily --- 
                ["Helvetica Neue"; "Lucida Grande"; 
                "Segoe UI"; "Arial"; "Helvetica"; "Verdana"; "sans-serif";] 
            ]
        a * [
            (%)visited <+> (%)link-|[
                color -- "#034af3"
                ]
            (%)hover-|[
                color -- "#1d60ff";
                textDecoration -- TextDecoration.none;
                ]
            ]
        p -|[
            marginBottom -- px 10
            lineHeight -- em 1.6
            ]
        "/* HEADINGS\n----------------------------------------------------------*/"
        [h1; h2; h3; h4; h5; h6]=|[
            fontSize -- em 1.5
            color -- "#666666"
            FontVariant.SmallCaps
            ]
        h1-|[
            fontSize -- em 1.6
            paddingBottom -- px 0
            marginBottom -- px 0
            ]
        h2-|[
            fontSize -- em 1.5
            fontWeight -- 600
            ]
        h3-|[
            fontSize -- em 1.2
            ]
        h4-|[
            fontSize -- em 1.1
            ]
        [h5; h6]=|[
            fontSize -- em 1.0
            ]
        "/* this rule styles <h1> and <h2> tags that are the \n first child of the left and right table columns */"
        [   (^)"rightColumn"    <>> h1;
            (^)"rightColumn"    <>> h2;
            (^)"leftColumn"     <>> h1;
            (^)"leftColumn"     <>> h2]=|[
            marginTop -- px 0
            ]
        "/* PRIMARY LAYOUT ELEMENTS\n----------------------------------------------------------*/"
        (^)page-|[
            width -- px 960;
            backgroundColor -- "#fff"
            margin ----
                [ px 20; auto; px 0; auto ]
            Border.Set <| px 1 <| Border.solid <| "#496077"
            ]
        (^)header * [
            (@)[position -- Position.relative
                margin -- px 0
                padding -- px 0
                background -- "#4b6c9e"
                width -- prc 100
                ];
            (+)h1-|[
                fontWeight -- 700
                ]
            ]
        (^)main-|[
            padding ---- pxx [0; 12]
            margin ---- pxx [12; 8; 8; 8]
            minHeight -- px 420
            ]
        (^)"leftCol"-|[
            padding ---- pxx [ 6; 12]
            margin ---- pxx [12; 8; 8; 8]
            width -- px 200
            minHeight -- px 200
            ]
        (^)footer-|[
            color -- "#4e5766"
            padding ---- pxx [8; 0; 0; 0]
            margin ---- [px 0; auto]
            textAlign -- TextAlign.center
            lineHeight -- LineHeight.normal
            ]
        "/* TAB MENU\n----------------------------------------------------------*/"
        div * [
            (^)"hideSkiplink"-|[
                backgroundColor -- "#3a4f63"
                width -- prc 100
                ]
            (^)"accountInfo"-|[ width -- prc 42 ]
            (^)menu * [
                (@)[padding ---- pxx [4; 0; 4; 8]]
                (+)ul * [
                    (@)[
                       listStyle -- ListStyle.none
                       margin -- px 0
                       padding -- px 0
                       width -- auto
                       ]
                    (+)li ++ a <-> div<^>menu ++ ul ++ li ++ a<%>visited -|[
                        backgroundColor -- "#465c71"
                        Border.Set <| px 1 <| Border.solid <| "#4e667d"
                        color -- "#dde4ec"
                        display -- Display.block
                        lineHeight -- em 1.35
                        padding ---- pxx [4; 20]
                        textDecoration -- TextDecoration.none
                        whiteSpace -- WhiteSpace.nowrap
                        ]
                    (+)li ++ a * [
                        (%)hover-|[
                            backgroundColor -- "#bfcbd6"
                            color -- "#465c71"
                            textDecoration -- TextDecoration.none
                            ]
                        (%)active-|[
                            backgroundColor -- "#465c71"
                            color -- "#cfdbe6"
                            textDecoration -- TextDecoration.none
                            ]
                        ]
                    ]
                ]
            ]
        "/* FORM ELEMENTS\n----------------------------------------------------------*/"
        "fieldset" * [
            (@) [
                margin ---- [em 1.0; px 0]
                padding -- em 1.0
                Border.Set <| px 1 <| Border.solid <| "#ccc"
                ]
            (+)p-|[ margin ---- pxx [2; 12; 10; 10] ]
            (^)"login"<^>"inline"-|[display -- Display.Inline]
            (^)"login" ++ label <+> (^)"register" ++ label <+> (^)"changePassword" ++ label-|[
                display -- Display.block
                ]
            ]
        "legend"-|[
            fontSize -- em 1.1
            fontWeight -- 600
            padding ---- pxx [2; 4; 8; 4]
            ]
        input * [
            (^)"textEntry "-|[
                width -- px 320
                Border.Set <| px 1 <| Border.solid <| "#ccc"
                ]
            (^)"passwordEntry"-|[
                width -- px 320
                Border.Set <| px 1 <| Border.solid <| "#ccc"
                ]
            ]
        "/* MISC\n----------------------------------------------------------*/"
        (^)clear-|[clear -- Clear.both]
        (^)title-|[
            display -- Display.block
            Float.Left
            ]
        (^)"loginDisplay" * [
            (@) [
                fontSize -- em 1.1
                Display.Block
                TextAlign.Right
                padding -- px 10
                Color.White
                ]
            (+)a * [
                (%)link-|[ Color.White ]
                (%)visited-|[ Color.White ]
                (%)"hover"-|[ Color.White ]
                ]
            ]
        (^)"failureNotification" -|[
            fontSize -- em 1.2
            Color.Red
            ]
        (^)"bold"-|[FontWeight.Bold]
        (^)"submitButton"-|[
            TextAlign.Right
            paddingRight -- px 10
            ]
        ]

"Build"; RunParameterTargetOrDefault "target" "Build"
```
