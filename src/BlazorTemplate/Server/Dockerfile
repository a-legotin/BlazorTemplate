FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/BlazorTemplate/Server/BlazorTemplate.Server.csproj", "BlazorTemplate/Server/"]
COPY ["src/BlazorTemplate/Client/BlazorTemplate.Client.csproj", "BlazorTemplate/Client/"]
COPY ["src/BlazorTemplate/Shared/BlazorTemplate.Shared.csproj", "BlazorTemplate/Shared/"]

RUN dotnet restore "BlazorTemplate/Server/BlazorTemplate.Server.csproj"
COPY src/. .
WORKDIR "/src/BlazorTemplate/Server"
RUN dotnet build "BlazorTemplate.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorTemplate.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BlazorTemplate.Server.dll"]
