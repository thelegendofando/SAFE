open System
open System.IO
open System.Threading.Tasks

open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection

open FSharp.Control.Tasks.V2
open Giraffe
open Shared
open Microsoft.AspNetCore.Http


let tryGetEnv = System.Environment.GetEnvironmentVariable >> function null | "" -> None | x -> Some x

let publicPath = Path.GetFullPath "../Client/public"
let port =
    "SERVER_PORT"
    |> tryGetEnv |> Option.map uint16 |> Option.defaultValue 8085us

let mutable value = { Value = 42 }

let init next ctx = 
    task {
        printfn "Getting value %i" value.Value
        return! json value next ctx
    }

let update next (ctx : HttpContext) =
    task {
        printf "Setting value "
        let! newValue = ctx.BindJsonAsync<Counter>()
        printfn "%i" newValue.Value
        value <- newValue

        return! Successful.OK "" next ctx
    }

let webApp =
    choose [
        GET  >=> choose [
            route "/api/init" >=> init
        ]
        POST >=> choose [
            route "/api/update" >=> update
        ]
        //route "/api/init" >=>
        //    fun next ctx ->
        //        task {
        //            return! json value next ctx
        //        }
    ]
    

let configureApp (app : IApplicationBuilder) =
    app.UseDefaultFiles()
       .UseStaticFiles()
       .UseGiraffe webApp

let configureServices (services : IServiceCollection) =
    services.AddGiraffe() |> ignore
    services.AddSingleton<Giraffe.Serialization.Json.IJsonSerializer>(Thoth.Json.Giraffe.ThothSerializer()) |> ignore

WebHost
    .CreateDefaultBuilder()
    .UseWebRoot(publicPath)
    .UseContentRoot(publicPath)
    .Configure(Action<IApplicationBuilder> configureApp)
    .ConfigureServices(configureServices)
    .UseUrls("http://0.0.0.0:" + port.ToString() + "/")
    .Build()
    .Run()
