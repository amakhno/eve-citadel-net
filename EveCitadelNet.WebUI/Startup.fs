namespace EveCitadelNet.WebUI

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.SpaServices.AngularCli;
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open EveCitadelNet.WebUI.Configuration
open System

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddControllers() |> ignore
        services.AddSpaStaticFiles(fun configuration -> 
            configuration.RootPath <- "ClientApp/dist"
        )
        services.AddTransient<EveAuthConfig>(fun _ -> 
            let cfg = new EveAuthConfig()            
            this.Configuration.GetSection("EveAuthConfig").Bind(cfg) |> ignore
            cfg
        ) |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseRouting() |> ignore

        app.UseAuthorization() |> ignore
        
        app.UseStaticFiles() |> ignore
        app.UseSpaStaticFiles() |> ignore

        app.UseEndpoints(fun endpoints ->
            endpoints.MapControllers() |> ignore
            ) |> ignore

        app.UseSpa(fun spa -> 
            spa.Options.SourcePath <- "ClientApp"
            
            if (env.IsDevelopment() && this.Configuration.GetValue<bool> "UseSpa") then
                spa.UseAngularCliServer("start")
            )

    member val Configuration : IConfiguration = null with get, set
