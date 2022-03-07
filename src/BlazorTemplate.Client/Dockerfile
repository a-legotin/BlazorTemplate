FROM  mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src

COPY ["src/BlazorTemplate.Client/BlazorTemplate.Client.csproj", "BlazorTemplate.Client/"]

RUN dotnet restore "BlazorTemplate.Client/BlazorTemplate.Client.csproj"
COPY src/. .
WORKDIR "/src/BlazorTemplate.Client"
RUN dotnet build "BlazorTemplate.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorTemplate.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "BlazorTemplate.Client.dll"]