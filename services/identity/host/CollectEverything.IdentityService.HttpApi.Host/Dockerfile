#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/identity/host/CollectEverything.IdentityService.HttpApi.Host/CollectEverything.IdentityService.HttpApi.Host.csproj", "services/identity/host/CollectEverything.IdentityService.HttpApi.Host/"]
COPY ["shared/CollectEverything.Hosting.Shared/CollectEverything.Hosting.Shared.csproj", "shared/CollectEverything.Hosting.Shared/"]
COPY ["services/administration/src/CollectEverything.Administration.EntityFrameworkCore/CollectEverything.Administration.EntityFrameworkCore.csproj", "services/administration/src/CollectEverything.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/CollectEverything.Administration.Domain/CollectEverything.Administration.Domain.csproj", "services/administration/src/CollectEverything.Administration.Domain/"]
COPY ["services/administration/src/CollectEverything.Administration.Domain.Shared/CollectEverything.Administration.Domain.Shared.csproj", "services/administration/src/CollectEverything.Administration.Domain.Shared/"]
COPY ["services/saas/src/CollectEverything.SaaS.EntityFrameworkCore/CollectEverything.SaaS.EntityFrameworkCore.csproj", "services/saas/src/CollectEverything.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/CollectEverything.SaaS.Domain/CollectEverything.SaaS.Domain.csproj", "services/saas/src/CollectEverything.SaaS.Domain/"]
COPY ["services/saas/src/CollectEverything.SaaS.Domain.Shared/CollectEverything.SaaS.Domain.Shared.csproj", "services/saas/src/CollectEverything.SaaS.Domain.Shared/"]
COPY ["services/identity/src/CollectEverything.IdentityService.HttpApi/CollectEverything.IdentityService.HttpApi.csproj", "services/identity/src/CollectEverything.IdentityService.HttpApi/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Application.Contracts/CollectEverything.IdentityService.Application.Contracts.csproj", "services/identity/src/CollectEverything.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Domain.Shared/CollectEverything.IdentityService.Domain.Shared.csproj", "services/identity/src/CollectEverything.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Application/CollectEverything.IdentityService.Application.csproj", "services/identity/src/CollectEverything.IdentityService.Application/"]
COPY ["services/identity/src/CollectEverything.IdentityService.Domain/CollectEverything.IdentityService.Domain.csproj", "services/identity/src/CollectEverything.IdentityService.Domain/"]
COPY ["services/identity/src/CollectEverything.IdentityService.EntityFrameworkCore/CollectEverything.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/CollectEverything.IdentityService.EntityFrameworkCore/"]
RUN dotnet restore "services/identity/host/CollectEverything.IdentityService.HttpApi.Host/CollectEverything.IdentityService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/identity/host/CollectEverything.IdentityService.HttpApi.Host"
RUN dotnet build "CollectEverything.IdentityService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectEverything.IdentityService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectEverything.IdentityService.HttpApi.Host.dll"]