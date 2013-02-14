Failess
=======

``` fsharp
#r @"FakeLib.dll"
#r @"FailessLib.dll"

open Fake
open Failess

Target "Build" (fun () -> 
    trace " --- Building CSS --- "
    pasteNewLine <- false
    CSS [
        "/* DEFAULTS\n----------------------------------------------------------*/"
        body-|[
            background -- "#b6b7bc";
            fontSize -- em 0.80;
            fontFamily --- 
                ["Helvetica Neue"; "Lucida Grande"; 
                "Segoe UI"; "Arial"; "Helvetica"; "Verdana"; "sans-serif";] 
            ];
        a * [
            (%)visited <+> (%)link-|[
                color -- "#034af3"
                ];
            (%)hover-|[
                color -- "#1d60ff";
                textDecoration -- TextDecoration.none;
                ];
            ];
        p -|[
            marginBottom -- px 10
            lineHeight -- em 1.6
            ]
        "/* HEADINGS\n----------------------------------------------------------*/"
        [h1; h2; h3; h4; h5; h6]=|[
            fontSize -- em 1.5;
            color -- "#666666";
            fontVariant -- FontVariant.smallCaps;
            ]
        h1-|[
            fontSize -- em 1.6;
            paddingBottom -- px 0;
            marginBottom -- px 0;
            ]
        h2-|[
            fontSize -- em 1.5;
            fontWeight -- 600;
            ]
        h3-|[
            fontSize -- em 1.2;
            ]
        h4-|[
            fontSize -- em 1.1;
            ]
        [h5; h6]=|[
            fontSize -- em 1.0;
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
            backgroundColor -- "#fff";
            margin ----
                [ px 20; auto; px 0; auto ]
            border ----
                [ px 1; s Border.solid; "#496077" ]
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
            padding ---- [px 0; px 12];
            margin ---- [px 12; px 8; px 8; px 8];
            minHeight -- px 420;
            ]
        (^)"leftCol"-|[
            padding ---- [px 6; px 12];
            margin ---- [px 12; px 8; px 8; px 8];
            width -- px 200
            minHeight -- px 200
            ]
        ]
    )

"Build"

RunParameterTargetOrDefault "target" "Build"
```
