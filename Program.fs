module SuaveMusicStore.App

open System

open Suave
open Suave.Successful
open Suave.Filters
open Suave.Operators
open Suave.RequestErrors

let html container =
    OK (View.index container)

let browse =
    request (fun r ->
        match r.queryParam "genre" with
        | Choice1Of2 genre -> html (View.browse genre)
        | Choice2Of2 msg -> BAD_REQUEST msg)

let webConfig =
    { defaultConfig with
        homeFolder = Some (__SOURCE_DIRECTORY__)
    }

let webPart = 
    choose [
        path Path.home >=> html View.home
        path Path.Store.overview >=> html View.store
        path Path.Store.browse >=> browse
        pathScan Path.Store.details (fun id -> html (View.details id))
        Files.browseHome
        RequestErrors.NOT_FOUND "Page not found." 
    ]

startWebServer webConfig webPart