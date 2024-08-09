FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/commandes/host/CollectEverything.Commandes.HttpApi.Host/CollectEverything.Commandes.HttpApi.Host.csproj", "services/commandes/host/CollectEverything.Commandes.HttpApi.Host/"]
COPY ["shared/CollectEverything.Hosting.Shared/CollectEverything.Hosting.Shared.csproj", "shared/CollectEverything.Hosting.Shared/"]
COPY ["services/commandes/src/CollectEverything.Commandes.HttpApi/CollectEverything.Commandes.HttpApi.csproj", "services/commandes/src/CollectEverything.Commandes.HttpApi/"]
COPY ["services/commandes/src/CollectEverything.Commandes.Application.Contracts/CollectEverything.Commandes.Application.Contracts.csproj", "services/commandes/src/CollectEverything.Commandes.Application.Contracts/"]
COPY ["services/commandes/src/CollectEverything.Commandes.Domain.Shared/CollectEverything.Commandes.Domain.Shared.csproj", "services/commandes/src/CollectEverything.Commandes.Domain.Shared/"]
COPY ["services/commandes/src/CollectEverything.Commandes.Application/CollectEverything.Commandes.Application.csproj", "services/commandes/src/CollectEverything.Commandes.Application/"]
COPY ["services/commandes/src/CollectEverything.Commandes.Domain/CollectEverything.Commandes.Domain.csproj", "services/commandes/src/CollectEverything.Commandes.Domain/"]
COPY ["services/commandes/src/CollectEverything.Commandes.EntityFrameworkCore/CollectEverything.Commandes.EntityFrameworkCore.csproj", "services/commandes/src/CollectEverything.Commandes.EntityFrameworkCore/"]
COPY ["services/commandes/host/CollectEverything.Commandes.Host.Shared/CollectEverything.Commandes.Host.Shared.csproj", "services/commandes/host/CollectEverything.Commandes.Host.Shared/"]
RUN dotnet restore "services/commandes/host/CollectEverything.Commandes.HttpApi.Host/CollectEverything.Commandes.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/commandes/host/CollectEverything.Commandes.HttpApi.Host"
RUN dotnet build "CollectEverything.Commandes.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CollectEverything.Commandes.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./docker/certificates/actual_certificates/certificate.crt /usr/local/share/ca-certificates/
RUN chmod 644 /usr/local/share/ca-certificates/certificate.crt && update-ca-certificates
ENTRYPOINT ["dotnet", "CollectEverything.Commandes.HttpApi.Host.dll"]
