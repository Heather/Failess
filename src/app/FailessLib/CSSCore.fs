[<AutoOpen>]
module Failess.CSSCore

open System
open System.ComponentModel

let (+++) a b = sprintf "%s%s" a b

type EnumToStringUsingDescription() =
    inherit TypeConverter()
    override X.CanConvertFrom(context : ITypeDescriptorContext, sourceType : Type) =
        sourceType.Equals(typedefof<Enum>);
    override X.CanConvertTo(context : ITypeDescriptorContext, destinationType : Type) =
        (destinationType.Equals(typedefof<String>));
    override X.ConvertFrom(context : ITypeDescriptorContext, culture : System.Globalization.CultureInfo, value : obj) =
        base.ConvertFrom(context, culture, value);
    override X.ConvertTo(context : ITypeDescriptorContext, culture : System.Globalization.CultureInfo, value : obj, destinationType : Type) =
        if (not <| destinationType.Equals(typedefof<String>)) then
            raise <| new ArgumentException("Can only convert to string.", "destinationType");

        if (not <| value.GetType().BaseType.Equals(typedefof<Enum>)) then
            raise <| new ArgumentException("Can only convert an instance of enum.", "value");

        let name = value.ToString();
        let attrs = 
            value.GetType().GetField(name).GetCustomAttributes(typedefof<DescriptionAttribute>, false);
        if (attrs.Length > 0) then attrs.[0]
        else value