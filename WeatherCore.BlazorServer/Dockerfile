FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WeatherCore.BlazorServer/WeatherCore.BlazorServer.csproj", "WeatherCore.BlazorServer/"]
RUN dotnet restore "WeatherCore.BlazorServer/WeatherCore.BlazorServer.csproj"
COPY . .
WORKDIR "/src/WeatherCore.BlazorServer"
RUN dotnet build "WeatherCore.BlazorServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherCore.BlazorServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherCore.BlazorServer.dll"]
