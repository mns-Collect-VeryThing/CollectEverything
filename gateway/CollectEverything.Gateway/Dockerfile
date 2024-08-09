#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["gateway/CollectEverything.Gateway/CollectEverything.Gateway.csproj", "gateway/CollectEverything.Gateway/"]
RUN dotnet restore "gateway/CollectEverything.Gateway/CollectEverything.Gateway.csproj"
COPY . .
WORKDIR "/src/gateway/CollectEverything.Gateway"
RUN dotnet build "CollectEverything.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectEverything.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./docker/certificates/actual_certificates/certificate.crt /usr/local/share/ca-certificates/
RUN chmod 644 /usr/local/share/ca-certificates/certificate.crt && update-ca-certificates
ENTRYPOINT ["dotnet", "CollectEverything.Gateway.dll"]