#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/projects/NuGet.Config", "services/projects/"]
COPY ["services/projects/host/CollectEverything.Projects.HttpApi.Host/CollectEverything.Projects.HttpApi.Host.csproj", "services/projects/host/CollectEverything.Projects.HttpApi.Host/"]
COPY ["services/projects/src/CollectEverything.Projects.HttpApi/CollectEverything.Projects.HttpApi.csproj", "services/projects/src/CollectEverything.Projects.HttpApi/"]
COPY ["services/projects/src/CollectEverything.Projects.Application.Contracts/CollectEverything.Projects.Application.Contracts.csproj", "services/projects/src/CollectEverything.Projects.Application.Contracts/"]
COPY ["services/projects/src/CollectEverything.Projects.Domain.Shared/CollectEverything.Projects.Domain.Shared.csproj", "services/projects/src/CollectEverything.Projects.Domain.Shared/"]
COPY ["services/projects/src/CollectEverything.Projects.Application/CollectEverything.Projects.Application.csproj", "services/projects/src/CollectEverything.Projects.Application/"]
COPY ["services/projects/src/CollectEverything.Projects.Domain/CollectEverything.Projects.Domain.csproj", "services/projects/src/CollectEverything.Projects.Domain/"]
COPY ["services/projects/src/CollectEverything.Projects.EntityFrameworkCore/CollectEverything.Projects.EntityFrameworkCore.csproj", "services/projects/src/CollectEverything.Projects.EntityFrameworkCore/"]
RUN dotnet restore "services/projects/host/CollectEverything.Projects.HttpApi.Host/CollectEverything.Projects.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/projects/host/CollectEverything.Projects.HttpApi.Host"
RUN dotnet build "CollectEverything.Projects.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectEverything.Projects.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectEverything.Projects.HttpApi.Host.dll"]