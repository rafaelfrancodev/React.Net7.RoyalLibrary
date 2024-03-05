#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["react.net7.royallibrary.client/nuget.config", "react.net7.royallibrary.client/"]
COPY ["React.Net7.RoyalLibrary.Server/React.Net7.RoyalLibrary.Server.csproj", "React.Net7.RoyalLibrary.Server/"]
COPY ["react.net7.royallibrary.client/react.net7.royallibrary.client.esproj", "react.net7.royallibrary.client/"]
RUN dotnet restore "./React.Net7.RoyalLibrary.Server/./React.Net7.RoyalLibrary.Server.csproj"
COPY . .
WORKDIR "/src/React.Net7.RoyalLibrary.Server"
RUN dotnet build "./React.Net7.RoyalLibrary.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./React.Net7.RoyalLibrary.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "React.Net7.RoyalLibrary.Server.dll"]