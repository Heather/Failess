open Fuchu
open Failess
open TestCSS

open System
open System.Text.RegularExpressions

let convertTest = 
    testCase "CSSConvert Test" <| 
        fun _ -> Assert.Equal("ToFailess"
            , failess
            , ToFailess <| ( Array.toList <| Regex.Split(css, "\r\n") )
            )
            
[<EntryPoint>]
let main argv = 
    run convertTest |> ignore
    0 // return an integer exit code
