namespace EveCitadelNet.WebUI.Configuration

type EveAuthConfig (clientId: string, secretKey: string, redirectUri: string, scope: string[]) =
    new () = EveAuthConfig(null, null, null, null)
    member val ClientId = clientId
    member val SecretKey = secretKey
    member val RedirectUri = redirectUri
    member val Scope = scope

    member val public StringedScope : string = scope |> String.concat " "
