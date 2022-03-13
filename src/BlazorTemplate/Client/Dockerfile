FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/BlazorTemplate.Client/BlazorTemplate.Client.csproj", "BlazorTemplate.Client/"]
COPY ["src/BlazorTemplate.Shared/BlazorTemplate.Shared.csproj", "BlazorTemplate.Shared/"]

RUN dotnet restore "BlazorTemplate.Client/BlazorTemplate.Client.csproj"
COPY src/. .
WORKDIR "/src/BlazorTemplate.Client"
RUN dotnet build "BlazorTemplate.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorTemplate.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorTemplate.Client.dll"]
