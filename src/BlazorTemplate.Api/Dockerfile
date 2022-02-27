FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorTemplate.Api/BlazorTemplate.Api.csproj", "BlazorTemplate.Api/"]
RUN dotnet restore "BlazorTemplate.Api/BlazorTemplate.Api.csproj"
COPY . .
WORKDIR "/src/BlazorTemplate.Api"
RUN dotnet build "BlazorTemplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorTemplate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorTemplate.Api.dll"]
