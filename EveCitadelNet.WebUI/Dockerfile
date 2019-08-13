FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["EveCitadelNet.WebUI/EveCitadelNet.WebUI.fsproj", "EveCitadelNet.WebUI/"]
RUN dotnet restore "EveCitadelNet.WebUI/EveCitadelNet.WebUI.fsproj"
COPY . .
WORKDIR "/src/EveCitadelNet.WebUI"
RUN dotnet build "EveCitadelNet.WebUI.fsproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EveCitadelNet.WebUI.fsproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EveCitadelNet.WebUI.dll"]