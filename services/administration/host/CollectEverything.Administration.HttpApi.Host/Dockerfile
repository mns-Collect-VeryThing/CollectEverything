#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/host/CollectEverything.Administration.HttpApi.Host/CollectEverything.Administration.HttpApi.Host.csproj", "services/administration/host/CollectEverything.Administration.HttpApi.Host/"]
COPY ["shared/CollectEverything.Hosting.Shared/CollectEverything.Hosting.Shared.csproj", "shared/CollectEverything.Hosting.Shared/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Application.Contracts/CollectEverything.IdentityService.Application.Contracts.csproj", "services/identity/src/CollectEverything.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Domain.Shared/CollectEverything.IdentityService.Domain.Shared.csproj", "services/identity/src/CollectEverything.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/CollectEverything.IdentityService.EntityFrameworkCore/CollectEverything.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/CollectEverything.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Domain/CollectEverything.IdentityService.Domain.csproj", "services/identity/src/CollectEverything.IdentityService.Domain/"]
COPY ["services/saas/src/CollectEverything.SaaS.Application.Contracts/CollectEverything.SaaS.Application.Contracts.csproj", "services/saas/src/CollectEverything.SaaS.Application.Contracts/"]
COPY ["services/saas/src/CollectEverything.SaaS.Domain.Shared/CollectEverything.SaaS.Domain.Shared.csproj", "services/saas/src/CollectEverything.SaaS.Domain.Shared/"]
COPY ["services/administration/src/CollectEverything.Administration.HttpApi/CollectEverything.Administration.HttpApi.csproj", "services/administration/src/CollectEverything.Administration.HttpApi/"]
COPY ["services/administration/src/CollectEverything.Administration.Application.Contracts/CollectEverything.Administration.Application.Contracts.csproj", "services/administration/src/CollectEverything.Administration.Application.Contracts/"]
COPY ["services/administration/src/CollectEverything.Administration.Domain.Shared/CollectEverything.Administration.Domain.Shared.csproj", "services/administration/src/CollectEverything.Administration.Domain.Shared/"]
COPY ["services/administration/src/CollectEverything.Administration.Application/CollectEverything.Administration.Application.csproj", "services/administration/src/CollectEverything.Administration.Application/"]
COPY ["services/administration/src/CollectEverything.Administration.Domain/CollectEverything.Administration.Domain.csproj", "services/administration/src/CollectEverything.Administration.Domain/"]
COPY ["services/administration/src/CollectEverything.Administration.EntityFrameworkCore/CollectEverything.Administration.EntityFrameworkCore.csproj", "services/administration/src/CollectEverything.Administration.EntityFrameworkCore/"]
RUN dotnet restore "services/administration/host/CollectEverything.Administration.HttpApi.Host/CollectEverything.Administration.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/administration/host/CollectEverything.Administration.HttpApi.Host"
RUN dotnet build "CollectEverything.Administration.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectEverything.Administration.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectEverything.Administration.HttpApi.Host.dll"]