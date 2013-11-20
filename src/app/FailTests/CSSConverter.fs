open Fuchu
open Failess
open TestCSS

open System
open System.Text.RegularExpressions

let convertTest = 
    testCase "CSSConvert Test" <| 
        fun _ -> Assert.Equal("ToFailess"
            , failess
            , toFailess <| ( Array.toList <| Regex.Split(css, "\r\n") )
            )
            
[<EntryPoint>]
let main argv = 
    let zz = ( Array.toList <| Regex.Split(css, "\r\n") )
    let cc = toFailess zz
    System.Console.WriteLine(cc)
    run convertTest |> ignore
    0 // return an integer exit code
