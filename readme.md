Failess ( F# CSS EDSL. ) builder
================================

[![Build Status](https://travis-ci.org/Heather/Failess.png?branch=master)](https://travis-ci.org/Heather/Failess)

Failess features:

 - Using FAKE ( https://github.com/fsharp/FAKE ) backend
 - Allow to use custom FSI=... (for Devil extension)
 - Allows unicode with Devil extension: https://github.com/Heather/DEVIL
 - Show FailessLib version
 - Readable color scheme for light-background terminals

``` fsharp
open Fake
open Failess

Target "custom.css" (fun () -> 
    CSS ("..\css\custom.css") [
        code @ Color.black
        "/* When highlighted code blocks are too wide, they wrap. Resulting in the */"
        "/* line numbers column's rows not lining up with the code rows. Prevent */"
        "/* wrapping. */"
        pre -|[
            whiteSpace  -- pre
            width       -- inh
        ]
    ]
); "custom.css"

RunParameterTargetOrDefault "target" "custom.css"
```

CSS EDSL (https://github.com/Heather/FailessLib )
-------------------------------------------------

FailessLib features:

 - Could be embedded in your application.
 - Highlighting as is F#.
 - Language sugar.
 - Making CSS relations with external things.
 - First class style properties.
 - First class selectors.
 - Typed values.
 - Nested style rules.
 - Access to outer scopes in nested rules.
 - Size and color arithmetics.
 - Recognizable syntax, inspired by CSS.
 - Easily extensible with new functionality.
 - Easy fall-back for uncovered parts.
 - Various options and styles.
 - Obfuscation
 - Devil unicode extension: https://github.com/Heather/DEVIL

``` fsharp
fieldset << [
    ★  [    
        margin -/ [em 1.0; px 0]
        padding -- em 1.0
        Border.set (px 1) Solid "#ccc" 
        ]
    ☆ p @ margin -/ px4 2 12 10 10
    ⠂ "login" ++ label 
        >< ⠂ "register" ++ label 
        >< ⠂ "changePassword" ++ label 
            @ Display.block 
    ]
⠂ loginDisplay << [
    ★  [
        fontSize       -- em 1.1
        padding        -- px 10
        Display.block
        TextAlign.right
        Color.white 
        ]
    ☆ a << [
        ⠅ link     @ Color.white
        ⠅ visited  @ Color.white
        ⠅ hover    @ Color.white
        ] ]
Border.set (px 1) Solid "#ccc" |> fun ➷ ->
    input << [
        ⠂ "textEntry "      -|[ ➷; width -- px 320 ]
        ⠂ "passwordEntry"   -|[ ➷; width -- px 320 ]
        ]
```

