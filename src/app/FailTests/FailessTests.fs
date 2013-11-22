open FailessTestData

open Fuchu
open Failess
open FailessTestData
open System.Text.RegularExpressions

let convertTest = 
    testCase "CSSConvert Test" <| 
        fun _ -> 
            Assert.Equal("ToFailess"
                , failess
                , toFailess <| 
                    ( Array.toList  
                        <| Regex.Split(css, System.Environment.NewLine))
                )

[<EntryPoint>]
let main _ = run convertTest