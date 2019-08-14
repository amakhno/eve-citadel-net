namespace EveCitadelNet.WebUI.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open EveCitadelNet.WebUI
open EveCitadelNet.WebUI.Configuration
open System.Web

[<ApiController>]
type EveAuthController (logger : ILogger<EveAuthController>, eveAuthConfig : EveAuthConfig) =
    inherit ControllerBase()

    let summaries = [| "Freezing"; "Bracing"; "Chilly"; "Cool"; "Mild"; "Warm"; "Balmy"; "Hot"; "Sweltering"; "Scorching" |]

    [<HttpGet>]
    [<Route("get-callback-address")>]
    member __.Get() : string =
        
        let uriBuilder = new UriBuilder("https://login.eveonline.com/oauth/authorize")
        let query = HttpUtility.ParseQueryString(uriBuilder.Query)
        query.["response_type"] <- "code"
        query.["redirect_uri"] <- "code"
        query.["scope"] <- eveAuthConfig.StringedScope
        uriBuilder.Query <- query.ToString()
        "https://login.eveonline.com/oauth/authorize"
 