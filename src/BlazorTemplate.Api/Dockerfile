FROM  mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src

COPY ["src/BlazorTemplate.Api/BlazorTemplate.Api.csproj", "BlazorTemplate.Api/"]

RUN dotnet restore "BlazorTemplate.Api/BlazorTemplate.Api.csproj"
COPY src/. .
WORKDIR "/src/BlazorTemplate.Api"
RUN dotnet build "BlazorTemplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorTemplate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8081
ENTRYPOINT ["dotnet", "BlazorTemplate.Api.dll"]