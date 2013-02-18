#r @"FakeLib.dll"
#r @"FailessLib.dll"
#r @"Heather.dll"

open Fake
open Failess
open Heather

Target "Build" /> fun () -> 
    trace " --- Building CSS --- "
    pasteNewLine <- false
    
    let (@) a b = a -| b
    let (^) a b = a =| b
    
    let PG = ".PG"
    let PGC = ".PGC"
    let PGC_OPEN = ".PGC_OPEN"
    let PGC_CLOSED = ".PGC_CLOSED"
    let PGC_HEAD = ".PGC_HEAD"
    let PGC_WRAP = ".PGC_WRAP"
    let PGH = ".PGH"
    let PGH_L = ".PGH_L"
    let PGH_R = ".PGH_R"
    let PGF = ".PGF"
    let PGF2 = ".PGF2"
    let PGI = ".PGI"
    let PGI_NONE = ".PGI_NONE"
    let PGI_CLOSED = ".PGI_CLOSED"
    let PGI_OPEN = ".PGI_OPEN"
    let PGI_NAME = ".PGI_NAME"
    let PGI_VALUE = ".PGI_VALUE"
    let PGI_NAME_SUB = ".PGI_NAME_SUB"
    
    
    CSS "..\Styles\PropertyGrid.css" [
        "/* DEFAULTS\n--------------------------------------------*/"
        PG * [
            - [ Float.left
                Display.block
                width -- px 300
                backgroundColor -- "lightgrey"
                fontFamily ---- ["verdana"]
                fontSize -- pt 8
                ]
            +img @ [ border -- px 0 ]
            +a % visited $ a % link $ a $ a % hover @ [
                TextDecoration.none
                ]
            ]
        [PGH; PGF2] ^ [ height -- px 20 ]
        [PGH; PGF; PGF2] ^ [
                Float.left
                margin -- px 0
                border --- [px 1; Border.solid]
            ]
        [PGH; PGF; PGC; PGF2] ^  [
            width -- prc 100
            Display.Inline
            ]
        PGH ++ img $ PGF2 ++ span @ [
            margin --- pxx [2; 1]
            ]
        PGF2 ++ span ++ img @ [
            margin --- pxx [0; 1]
            ]
        PGH_L @ [
            Float.left
            Cursor.pointer
            ]
        PGH_R @ [
            Float.right
            Cursor.pointer
            ]
        PGF * [
            - [ height -- px 100
                borderBottom --- [px 0; Border.none]
                ]
            + span @ [
                Display.block
                margin -- px 2
                ]
            ]
        PGC * [
            - [ Float.left
                borderLeft  --- [px 1; Border.solid]
                borderRight --- [px 1; Border.solid]
                ]
            + a @ [ Display.block]
            ]
        PGC_OPEN $ PGC_CLOSED @ [
            width -- px 18
            Float.left
            Cursor.pointer
            ]
        PGC_OPEN @ [
            background --- [
                url("grey-open.png") 
                s Background.NoRepeat 
                s Background.Center
                ]
            ]
        PGC_CLOSED @ [
            background --- [
                url("grey-open.png") 
                s Background.NoRepeat 
                s Background.Center
                ]
            ]
        PGC_HEAD * [
            - [Float.left]
            + span @ [
                FontWeight.bold
                marginLeft -- px 2
                ]
            ]
        PGC_WRAP @ [ Clear.both ]
        PGI @ [ width -- prc 100 ]
        PGI_NONE $ PGI_CLOSED $ PGI_OPEN @ [
            Float.left
            width -- px 18
            height -- px 20
            ]
        PGI_CLOSED @ [
            Cursor.pointer
            background --- [
                url("white-closed.png")
                s Background.NoRepeat 
                s Background.Center
                ]
            ]
        PGI_OPEN @ [
            Cursor.pointer
            background --- [
                url("white-open.png")
                s Background.NoRepeat 
                s Background.Center
                ]
            ]
        PGI_NAME $ PGI_VALUE $ PGI_NAME_SUB @ [
            Float.left
            margin --- pxx [1; 0; 0; 1]
            Cursor.pointer
            Overflow.hidden
            width -- px 138
            ]
        PGI_VALUE ++ a $ PGI_VALUE ++ "select" @ [
            width -- prc 100
            ]
        PGI_NAME ++ span @ [
            marginLeft -- px 3
            ]
        PGI_VALUE ++ span @ [
            marginLeft -- px 2
            ]
        PGI_VALUE ++ a @ [
            paddingLeft -- px 2
            ]
        PGI_VALUE * [
            +"select" @ [
                Display.block
                margin -- px 0
                paddingBottom -- px 2
                border -- 0
                ]
            +input @ [
                Overflow.hidden
                paddingLeft -- px 2
                border -- 0
                ]
            ]
        ]

"Build"; RunParameterTargetOrDefault "target" "Build"