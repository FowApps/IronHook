#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["samples/dotnet6/IronHook.Web/IronHook.Web.csproj", "samples/dotnet6/IronHook.Web/"]
COPY ["src/IronHook.EntityFrameworkCore.PostgreSql/IronHook.EntityFrameworkCore.PostgreSql.csproj", "src/IronHook.EntityFrameworkCore.PostgreSql/"]
COPY ["src/IronHook.EntityFrameworkCore/IronHook.EntityFrameworkCore.csproj", "src/IronHook.EntityFrameworkCore/"]
COPY ["src/IronHook.Core/IronHook.Core.csproj", "src/IronHook.Core/"]
RUN dotnet restore "./samples/dotnet6/IronHook.Web/./IronHook.Web.csproj"
COPY . .
WORKDIR "/src/samples/dotnet6/IronHook.Web"
RUN dotnet build "./IronHook.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IronHook.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet IronHook.Web.dll