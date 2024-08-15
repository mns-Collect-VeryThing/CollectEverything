FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/shops/host/CollectEverything.shops.HttpApi.Host/CollectEverything.Shops.HttpApi.Host.csproj", "services/shops/host/CollectEverything.shops.HttpApi.Host/"]
COPY ["services/shops/src/CollectEverything.shops.HttpApi/CollectEverything.Shops.HttpApi.csproj", "services/shops/src/CollectEverything.shops.HttpApi/"]
COPY ["services/shops/src/CollectEverything.shops.Application.Contracts/CollectEverything.Shops.Application.Contracts.csproj", "services/shops/src/CollectEverything.shops.Application.Contracts/"]
COPY ["services/shops/src/CollectEverything.shops.Domain.Shared/CollectEverything.Shops.Domain.Shared.csproj", "services/shops/src/CollectEverything.shops.Domain.Shared/"]
COPY ["services/shops/src/CollectEverything.shops.Application/CollectEverything.Shops.Application.csproj", "services/shops/src/CollectEverything.shops.Application/"]
COPY ["services/shops/src/CollectEverything.shops.Domain/CollectEverything.Shops.Domain.csproj", "services/shops/src/CollectEverything.shops.Domain/"]
COPY ["services/shops/src/CollectEverything.shops.EntityFrameworkCore/CollectEverything.Shops.EntityFrameworkCore.csproj", "services/shops/src/CollectEverything.shops.EntityFrameworkCore/"]
COPY ["services/shops/host/CollectEverything.shops.Host.Shared/CollectEverything.Shops.Host.Shared.csproj", "services/shops/host/CollectEverything.shops.Host.Shared/"]
COPY ["shared/CollectEverything.Hosting.Shared/CollectEverything.Hosting.Shared.csproj", "shared/CollectEverything.Hosting.Shared/"]
RUN dotnet restore "services/shops/host/CollectEverything.shops.HttpApi.Host/CollectEverything.Shops.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/shops/host/CollectEverything.shops.HttpApi.Host"
RUN dotnet build "CollectEverything.Shops.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CollectEverything.Shops.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./docker/certificates/actual_certificates/certificate.crt /usr/local/share/ca-certificates/
RUN chmod 644 /usr/local/share/ca-certificates/certificate.crt && update-ca-certificates
ENTRYPOINT ["dotnet", "CollectEverything.Shops.HttpApi.Host.dll"]
