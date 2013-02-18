Failess - CSS EDSL <embedded domain specific language> in F#
============================================================

Some features list (based on Clay) just to show why do I make it

 - FAKE integration.
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

Check for examples in examples folder
-------------------------------------

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
// Nested types:
div * [
	&"hideSkiplink"-|[
		backgroundColor -- "#3a4f63"
		width 			-- prc 100
		]
	&"accountInfo"-|[ width -- prc 42 ]
	&menu * [
		- [padding --- pxx [4; 0; 4; 8]]
		+ ul * [ ...
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
