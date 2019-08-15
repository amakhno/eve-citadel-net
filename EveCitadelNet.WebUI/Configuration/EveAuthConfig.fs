namespace EveCitadelNet.WebUI.Configuration

type EveAuthConfig () =
    member val ClientId = "" with get, set
    member val SecretKey = "" with get, set
    member val RedirectUri = "" with get, set
    member val Scopes = Array.empty<string> with get, set 

    member this.GetStringedScope() = 
        (" ", this.Scopes) |> System.String.Join
