#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq && npm update
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq && npm update
WORKDIR /src
COPY ["ProxyReverse.WebApp/ProxyReverse.WebApp.csproj", "ProxyReverse.WebApp/"]
COPY ["ProxyReverse.Web.DependencyInjection/ProxyReverse.Web.DependencyInjection.csproj", "ProxyReverse.Web.DependencyInjection/"]
COPY ["ProxyReverse.RabitMqInterface/RabitMqInterface.csproj", "ProxyReverse.RabitMqInterface/"]
COPY ["ProxyReverse.Web.Core/ProxyReverse.Web.Core.csproj", "ProxyReverse.Web.Core/"]
COPY ["DependencyInjection/DependencyInjection.csproj", "DependencyInjection/"]
COPY ["Base.Core/Base.Core.csproj", "Base.Core/"]
COPY ["Json.NewtonSoft.ThirdParty/Json.NewtonSoft.ThirdParty.csproj", "Json.NewtonSoft.ThirdParty/"]
RUN dotnet restore "ProxyReverse.WebApp/ProxyReverse.WebApp.csproj"
COPY . .
WORKDIR "/src/ProxyReverse.WebApp"
RUN dotnet build "ProxyReverse.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProxyReverse.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProxyReverse.WebApp.dll"]