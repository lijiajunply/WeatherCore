FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WeatherCore.BS/WeatherCore.BS.csproj", "WeatherCore.BS/"]
RUN dotnet restore "WeatherCore.BS/WeatherCore.BS.csproj"
COPY . .
WORKDIR "/src/WeatherCore.BS"
RUN dotnet build "WeatherCore.BS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherCore.BS.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherCore.BS.dll"]
