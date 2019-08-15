namespace EveCitadelNet.WebUI.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
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
        query.["redirect_uri"] <- eveAuthConfig.RedirectUri
        query.["client_id"] <- eveAuthConfig.ClientId
        uriBuilder.Query <- query.ToString()
        uriBuilder.ToString()

    [<HttpGet>]
    [<Route("callback")>]
    member __.Callback(code: string) : string =      
        code
 