open FailessTestData

open Fuchu
open Failess
open FailessTestData
open System.Text.RegularExpressions

let convertTest = 
    testCase "CSSConvert Test" <| 
        fun _ -> 
            let actual = toFailess <| ( Array.toList  
                                      <| Regex.Split
                                          (css, System.Environment.NewLine))
            "Actual : " + actual |> System.Console.WriteLine
            Assert.Equal("ToFailess"
                , failess
                , actual
                )

[<EntryPoint>]
let main _ = run convertTest