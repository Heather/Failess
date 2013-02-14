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
                ];
            a * [
                visited-|[
                    color -- "#034af3"
                    ];
                link-|[
                    color -- "#034af3"
                    ];
                hover-|[
                    color -- "#1d60ff";
                    textDecoration -- TextDecoration.none;
                    ];
                ]
            ]
    with | _ as exc ->
        trace (" --- Failed to build: " + exc.Message)
    )
```
