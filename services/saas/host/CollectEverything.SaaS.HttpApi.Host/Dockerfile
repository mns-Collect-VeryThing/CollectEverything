#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/host/CollectEverything.SaaS.HttpApi.Host/CollectEverything.SaaS.HttpApi.Host.csproj", "services/saas/host/CollectEverything.SaaS.HttpApi.Host/"]
COPY ["shared/CollectEverything.Hosting.Shared/CollectEverything.Hosting.Shared.csproj", "shared/CollectEverything.Hosting.Shared/"]
COPY ["services/administration/src/CollectEverything.Administration.EntityFrameworkCore/CollectEverything.Administration.EntityFrameworkCore.csproj", "services/administration/src/CollectEverything.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/CollectEverything.Administration.Domain/CollectEverything.Administration.Domain.csproj", "services/administration/src/CollectEverything.Administration.Domain/"]
COPY ["services/administration/src/CollectEverything.Administration.Domain.Shared/CollectEverything.Administration.Domain.Shared.csproj", "services/administration/src/CollectEverything.Administration.Domain.Shared/"]
COPY ["services/saas/src/CollectEverything.SaaS.HttpApi/CollectEverything.SaaS.HttpApi.csproj", "services/saas/src/CollectEverything.SaaS.HttpApi/"]
COPY ["services/saas/src/CollectEverything.SaaS.Application.Contracts/CollectEverything.SaaS.Application.Contracts.csproj", "services/saas/src/CollectEverything.SaaS.Application.Contracts/"]
COPY ["services/saas/src/CollectEverything.SaaS.Domain.Shared/CollectEverything.SaaS.Domain.Shared.csproj", "services/saas/src/CollectEverything.SaaS.Domain.Shared/"]
COPY ["services/saas/src/CollectEverything.SaaS.Application/CollectEverything.SaaS.Application.csproj", "services/saas/src/CollectEverything.SaaS.Application/"]
COPY ["services/saas/src/CollectEverything.SaaS.Domain/CollectEverything.SaaS.Domain.csproj", "services/saas/src/CollectEverything.SaaS.Domain/"]
COPY ["services/saas/src/CollectEverything.SaaS.EntityFrameworkCore/CollectEverything.SaaS.EntityFrameworkCore.csproj", "services/saas/src/CollectEverything.SaaS.EntityFrameworkCore/"]
RUN dotnet restore "services/saas/host/CollectEverything.SaaS.HttpApi.Host/CollectEverything.SaaS.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/saas/host/CollectEverything.SaaS.HttpApi.Host"
RUN dotnet build "CollectEverything.SaaS.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectEverything.SaaS.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./docker/certificates/actual_certificates/certificate.crt /usr/local/share/ca-certificates/
RUN chmod 644 /usr/local/share/ca-certificates/certificate.crt && update-ca-certificates
ENTRYPOINT ["dotnet", "CollectEverything.SaaS.HttpApi.Host.dll"]