#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["shared/CollectEverything.DbMigrator/CollectEverything.DbMigrator.csproj", "shared/CollectEverything.DbMigrator/"]
COPY ["services/administration/src/CollectEverything.Administration.Application.Contracts/CollectEverything.Administration.Application.Contracts.csproj", "services/administration/src/CollectEverything.Administration.Application.Contracts/"]
COPY ["services/administration/src/CollectEverything.Administration.Domain.Shared/CollectEverything.Administration.Domain.Shared.csproj", "services/administration/src/CollectEverything.Administration.Domain.Shared/"]
COPY ["services/administration/src/CollectEverything.Administration.EntityFrameworkCore/CollectEverything.Administration.EntityFrameworkCore.csproj", "services/administration/src/CollectEverything.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/CollectEverything.Administration.Domain/CollectEverything.Administration.Domain.csproj", "services/administration/src/CollectEverything.Administration.Domain/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Application.Contracts/CollectEverything.IdentityService.Application.Contracts.csproj", "services/identity/src/CollectEverything.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Domain.Shared/CollectEverything.IdentityService.Domain.Shared.csproj", "services/identity/src/CollectEverything.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/CollectEverything.IdentityService.EntityFrameworkCore/CollectEverything.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/CollectEverything.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Domain/CollectEverything.IdentityService.Domain.csproj", "services/identity/src/CollectEverything.IdentityService.Domain/"]
COPY ["services/saas/src/CollectEverything.SaaS.Application.Contracts/CollectEverything.SaaS.Application.Contracts.csproj", "services/saas/src/CollectEverything.SaaS.Application.Contracts/"]
COPY ["services/saas/src/CollectEverything.SaaS.Domain.Shared/CollectEverything.SaaS.Domain.Shared.csproj", "services/saas/src/CollectEverything.SaaS.Domain.Shared/"]
COPY ["services/saas/src/CollectEverything.SaaS.EntityFrameworkCore/CollectEverything.SaaS.EntityFrameworkCore.csproj", "services/saas/src/CollectEverything.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/CollectEverything.SaaS.Domain/CollectEverything.SaaS.Domain.csproj", "services/saas/src/CollectEverything.SaaS.Domain/"]
COPY ["shared/CollectEverything.Microservice.Shared/CollectEverything.Microservice.Shared.csproj", "shared/CollectEverything.Microservice.Shared/"]
COPY ["shared/CollectEverything.Hosting.Shared/CollectEverything.Hosting.Shared.csproj", "shared/CollectEverything.Hosting.Shared/"]
RUN dotnet restore "shared/CollectEverything.DbMigrator/CollectEverything.DbMigrator.csproj"
COPY . .
WORKDIR "/src/shared/CollectEverything.DbMigrator"
RUN dotnet build "CollectEverything.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectEverything.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectEverything.DbMigrator.dll"]