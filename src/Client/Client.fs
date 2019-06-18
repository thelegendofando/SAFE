module Client

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Thoth.Fetch
open Fulma

open Shared

type Model = { State: State option }

type Msg =
| Increment
| Decrement
| InitialCountLoaded of State

let initialCounter () = Fetch.fetchAs<State> "/api/init"
let updateServer (counter:State) =
    promise {
        let! response = Fetch.post("/api/update", counter)
        printfn "%O" response
    } 
    |> Promise.start

let init () : Model * Cmd<Msg> =
    let initialModel = { State = None }
    let loadCountCmd =
        Cmd.OfPromise.perform initialCounter () InitialCountLoaded
    initialModel, loadCountCmd

let update (msg : Msg) (currentModel : Model) : Model * Cmd<Msg> =
    let getCounter (Counter state) = state
    let next state fn =
        let current = getCounter state
        State.Counter { current with Value = fn current.Value 1 }
    match currentModel.State, msg with
    | Some counter, Increment ->
        let nextValue = next counter (+)
        let nextModel = { currentModel with State = Some nextValue }
        updateServer nextValue |> ignore
        nextModel, Cmd.none
    | Some counter, Decrement ->
        let nextValue = next counter (-)
        let nextModel = { currentModel with State = Some nextValue }
        updateServer nextValue |> ignore
        nextModel, Cmd.none
    | _, InitialCountLoaded initialCount->
        let nextModel = { State = Some initialCount }
        nextModel, Cmd.none
    | _ -> currentModel, Cmd.none


let safeComponents =
    let components =
        span [ ]
           [
             a [ Href "https://github.com/giraffe-fsharp/Giraffe" ] [ str "Giraffe" ]
             str ", "
             a [ Href "http://fable.io" ] [ str "Fable" ]
             str ", "
             a [ Href "https://elmish.github.io/elmish/" ] [ str "Elmish" ]
             str ", "
             a [ Href "https://fulma.github.io/Fulma" ] [ str "Fulma" ]

           ]

    span [ ]
        [ strong [] [ str "SAFE innit" ]
          str " powered by: "
          components ]

let getStringValue state =
    match state with
    | Counter c -> string c.Value

let show = function
| { State = Some counter } -> getStringValue counter
| { State = None   } -> "Loading..."

let button txt onClick =
    Button.button
        [ Button.IsFullWidth
          Button.Color IsPrimary
          Button.OnClick onClick ]
        [ str txt ]

let view (model : Model) (dispatch : Msg -> unit) =
    div []
        [ Navbar.navbar [ Navbar.Color IsPrimary ]
            [ Navbar.Item.div [ ]
                [ Heading.h2 [ ]
                    [ str "SAFE Template" ] ] ]

          Container.container []
              [ Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
                    [ Heading.h3 [] [ str ("Press buttons to manipulate counter: " + show model) ] ]
                Columns.columns []
                    [ Column.column [] [ button "-" (fun _ -> dispatch Decrement) ]
                      Column.column [] [ button "+" (fun _ -> dispatch Increment) ] ] ]

          Footer.footer [ ]
                [ Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
                    [ safeComponents ] ] ]

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactBatched "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
