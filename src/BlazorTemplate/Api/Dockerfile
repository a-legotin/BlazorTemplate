FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/BlazorTemplate/Api/BlazorTemplate.Api.csproj", "BlazorTemplate/Api/"]
COPY ["src/BlazorTemplate/Shared/BlazorTemplate.Shared.csproj", "BlazorTemplate/Shared/"]

RUN dotnet restore "BlazorTemplate/Api/BlazorTemplate.Api.csproj"
COPY src/. .
WORKDIR "/src/BlazorTemplate/Api"
RUN dotnet build "BlazorTemplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorTemplate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BlazorTemplate.Api.dll"]