namespace Reactstrap

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Reactstrap
open Fable.React.Props

[<RequireQualifiedAccess>]
module Pagination =

    type PaginationProps =
        | CssModule of CSSModule
        | Size of Common.Size
        | ListClassName of string
        | ListTag of string
        | [<CompiledName("aria-label")>] AriaLabel of string
        | Tag of U2<string, obj>
        | Custom of IHTMLProp list

    let pagination (props: PaginationProps seq) (elems: ReactElement seq): ReactElement =
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
        ofImport "Pagination" "reactstrap" props elems
