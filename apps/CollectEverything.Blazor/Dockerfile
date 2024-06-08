FROM nginx:alpine AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["apps/CollectEverything.Blazor/CollectEverything.Blazor.csproj", "apps/CollectEverything.Blazor/"]
RUN dotnet restore "apps/CollectEverything.Blazor/CollectEverything.Blazor.csproj"
COPY . .

WORKDIR "/src/apps/CollectEverything.Blazor/"
RUN dotnet build "CollectEverything.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "CollectEverything.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY apps/CollectEverything.Blazor/nginx.conf /etc/nginx/nginx.conf



FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
RUN apk add nodejs
RUN apk add npm
WORKDIR /apps
COPY ["apps/CollectEverything.Blazor/CollectEverything.Blazor.csproj", "apps/CollectEverything.Blazor/"]
RUN npm --prefix Web install
RUN dotnet publish "Web/Web.csproj" -c Release -o output

FROM nginx:alpine
WORKDIR /user/share/nginx/html
COPY --from=build-env /app/output/wwwroot .
COPY Web/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80