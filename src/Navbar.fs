namespace Reactstrap

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Reactstrap
open Fable.React.Props

[<RequireQualifiedAccess>]
module Navbar =

    type NavbarProps =

        | Tag of U2<string, obj>
        | Light of bool
        | Dark of bool
        | Fixed of string
        | Color of Common.Color
        | Role of string
        | Expand of U2<bool, Common.Size>
        | Custom of IHTMLProp list

    let navbar (props: NavbarProps seq) (elems: ReactElement seq): ReactElement =
        let customProps =
            props
            |> Seq.collect (function
                | Custom props -> props
                | _ -> List.empty)
            |> keyValueList CaseRules.LowerFirst

        let typeProps =
            props
            |> Seq.choose (function
                | Custom _ -> None
                | prop -> Some prop)
            |> keyValueList CaseRules.LowerFirst

        let props = JS.Object.assign (createEmpty, customProps, typeProps)

        ofImport "Navbar" "reactstrap" props elems
