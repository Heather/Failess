Failess
=======

``` fsharp
Target "Build" (fun () -> 
    trace " --- Building Failess --- "
    try
        CSS [
            "/* DEFAULTS\n----------------------------------------------------------*/"
            body-|[
                background -- "#b6b7bc";
                fontSize -- ".80em";
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
            ]
    with | _ as exc ->
        trace (" --- Failed to build: " + exc.Message)
    )
```
