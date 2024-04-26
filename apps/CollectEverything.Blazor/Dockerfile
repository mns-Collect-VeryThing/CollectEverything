FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["apps/CollectEverything.Blazor/CollectEverything.Blazor.csproj", "apps/CollectEverything.Blazor/"]
RUN dotnet restore "apps/CollectEverything.Blazor/CollectEverything.Blazor.csproj"
COPY . .
WORKDIR "/src/apps/CollectEverything.Blazor"
RUN dotnet build "CollectEverything.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CollectEverything.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectEverything.Blazor.dll"]
