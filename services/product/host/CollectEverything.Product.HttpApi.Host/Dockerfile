FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/product/host/CollectEverything.Product.HttpApi.Host/CollectEverything.Product.HttpApi.Host.csproj", "services/product/host/CollectEverything.Product.HttpApi.Host/"]
COPY ["services/product/src/CollectEverything.Product.HttpApi/CollectEverything.Product.HttpApi.csproj", "services/product/src/CollectEverything.Product.HttpApi/"]
COPY ["services/product/src/CollectEverything.Product.Application.Contracts/CollectEverything.Product.Application.Contracts.csproj", "services/product/src/CollectEverything.Product.Application.Contracts/"]
COPY ["services/product/src/CollectEverything.Product.Domain.Shared/CollectEverything.Product.Domain.Shared.csproj", "services/product/src/CollectEverything.Product.Domain.Shared/"]
COPY ["services/product/src/CollectEverything.Product.Application/CollectEverything.Product.Application.csproj", "services/product/src/CollectEverything.Product.Application/"]
COPY ["services/product/src/CollectEverything.Product.Domain/CollectEverything.Product.Domain.csproj", "services/product/src/CollectEverything.Product.Domain/"]
COPY ["services/product/src/CollectEverything.Product.EntityFrameworkCore/CollectEverything.Product.EntityFrameworkCore.csproj", "services/product/src/CollectEverything.Product.EntityFrameworkCore/"]
COPY ["services/product/host/CollectEverything.Product.Host.Shared/CollectEverything.Product.Host.Shared.csproj", "services/product/host/CollectEverything.Product.Host.Shared/"]
COPY ["shared/CollectEverything.Hosting.Shared/CollectEverything.Hosting.Shared.csproj", "shared/CollectEverything.Hosting.Shared/"]
RUN dotnet restore "services/product/host/CollectEverything.Product.HttpApi.Host/CollectEverything.Product.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/product/host/CollectEverything.Product.HttpApi.Host"
RUN dotnet build "CollectEverything.Product.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CollectEverything.Product.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./docker/certificates/actual_certificates/certificate.crt /usr/local/share/ca-certificates/
RUN chmod 644 /usr/local/share/ca-certificates/certificate.crt && update-ca-certificates
ENTRYPOINT ["dotnet", "CollectEverything.Product.HttpApi.Host.dll"]
