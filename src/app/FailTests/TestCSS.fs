module TestCSS

let css = @"
.mleft, .mright {
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
}
"

let failess = @".mleft, .mright -| [
            vertical-align-- central;
            text-align-- center;
            margin-bottom-- 10px;
            min-height-- 500px;
    ]
.mleft -| [
            width-- 59%;
            float-- left;
            vertical-align-- central;
            text-align-- center;
            margin-bottom-- 10px;
            min-height-- 500px;
    ]
.mright -| [
            width-- 39%;
            float-- right;
            width-- 59%;
            float-- left;
            vertical-align-- central;
            text-align-- center;
            margin-bottom-- 10px;
            min-height-- 500px;
    ]
.RedColored -| [
            background-- #FF0000;
            width-- 39%;
            float-- right;
            width-- 59%;
            float-- left;
            vertical-align-- central;
            text-align-- center;
            margin-bottom-- 10px;
            min-height-- 500px;
    ]"