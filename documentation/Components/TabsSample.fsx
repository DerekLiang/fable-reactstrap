#load "../../.paket/load/netstandard2.0/main.group.fsx"
#load "../../src/Common.fs"
#load "../../src/Tabs.fs"

open Fable.Core.JsInterop
open Fable.React
open ReactStrap

let private tabsSample =
    FunctionComponent.Of<obj> (fun _ ->
        fragment [] [
        ]
    , "TabsSample")
    
exportDefault tabsSample