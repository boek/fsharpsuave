module SuaveMusicStore.View

open Suave.Html

let divId id = divAttr ["id", id]
let h1 = tag "h1" []
let h2 s = tag "h2" [] (text s)
let cssLink href = linkAttr [ "href", href; " rel", "stylesheet"; " type", "text/css" ]
let ul xml = tag "ul" [] xml
let li = tag "li" []

let index container = 
    html [
        head [
            title "Suave Music Store"
            cssLink "/public/main.css"
        ]

        body [
            divId "header" [
                h1 [ (a Path.home (text "F# Suave Music Store")) ]
            ]

            divId "main" container

            divId "footer" [
                Text "Built with "
                a "http://fsharp.org/" (text "F#")
                Text " and "
                a "http://suave.io" (text "SuaveIO")
            ]
        ]
    ]
    |> htmlToString

let home =
    text "Home"

let store genres = [
    h2 "Browse Genres"
    p [
        Text (sprintf "Select from %d genres:" (List.length genres))
    ]
    ul [
        for g in genres ->
            li [
                (a (Path.Store.browse |> Path.withParam (Path.Store.browseKey, g)) (text g))
            ]
    ]
]

let browse genre =
    text (sprintf "Genre: %s" genre)

let details id =
    text (sprintf "Details %d" id)