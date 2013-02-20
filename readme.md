Failess FAKE integration
========================

``` fsharp
// Relations with external things:
&page-|[
	width -- 
		match style with
		| styles.Full       -> prc 100
		| _                 -> px 960
	backgroundColor -- "#fff"
	Border.set "1px" Border.Solid "#496077"
	]
// Nested types & CSS variables
let menuStyle = [ 
	TextDecoration.none
	WhiteSpace.noWrap
	]
div * [
	&"hideSkiplink"-|[
		backgroundColor -- "#3a4f63"
		width -- prc 100
		]
	&"accountInfo"-|[ width -- prc 42 ]
	&menu * [
		-  [padding --- pxx [4; 0; 4; 8]]
		+ul * [
			- [listStyle -- ListStyle.None
			   margin 	-- px 0
			   padding 	-- px 0
			   width 	-- auto
			   ]
			+li ++ a * [
				- menuStyle
// With...:
Border.set "1px" Border.Solid "#ccc" 
|> fun borderForInput ->
	input * [
		& "textEntry "-|[
			borderForInput
			]
		& "passwordEntry"-|[
			width -- px 320
			borderForInput
			]
		]
// Custom stuff:
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
```
