module TestCSS

let css = @".mleft, .mright {
    min-height: 500px;
    margin-bottom: 10px;
    text-align: center;
    vertical-align: central;
}
.mleft {
    float: left;
    width: 59%;
}
.mright {
    float: right;
    width: 39%;
}
.RedColored {
    background: #FF0000;
}"

let failess = """-."mleft$" -."mright" -| [
        "vertical-align" -- central
        text-align -- center
        margin-bottom --px 10
        min-height --px 500
    ]
-."mleft" -| [
        width --prc 59
        "float" -- left
    ]
-."mright" -| [
        width --prc 39
        "float" -- right
    ]
-."RedColored" -| [
        background -- #FF0000
    ]"""