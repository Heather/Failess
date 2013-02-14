Failess
=======

``` fsharp
Target "Build" (fun () -> 
    trace " --- Building Failess --- "
    try
        CSS [
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
            [h1; h2; h3; h4; h5; h6]=|[
                fontSize -- em 1.5;
                color -- "#666666";
                fontVariant -- FontVariant.smallCaps;
                ]
            ]
    with | _ as exc ->
        trace (" --- Failed to build: " + exc.Message)
    )
```
