#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY common.props ./
COPY ["samples/dotnet6/IronHook.Web/IronHook.Web.csproj", "samples/dotnet6/IronHook.Web/"]
COPY ["src/IronHook.EntityFrameworkCore.PostgreSql/IronHook.EntityFrameworkCore.PostgreSql.csproj", "src/IronHook.EntityFrameworkCore.PostgreSql/"]
COPY ["src/IronHook.EntityFrameworkCore/IronHook.EntityFrameworkCore.csproj", "src/IronHook.EntityFrameworkCore/"]
COPY ["src/IronHook.Core/IronHook.Core.csproj", "src/IronHook.Core/"]
RUN dotnet restore "samples/dotnet6/IronHook.Web/IronHook.Web.csproj"
COPY . .
WORKDIR "/src/samples/dotnet6/IronHook.Web"
RUN dotnet build "IronHook.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IronHook.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet IronHook.Web.dll