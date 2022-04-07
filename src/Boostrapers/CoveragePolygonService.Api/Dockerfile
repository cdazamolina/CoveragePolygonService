#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Boostrapers/CoveragePolygonService.Api/CoveragePolygonService.Api.csproj", "src/Boostrapers/CoveragePolygonService.Api/"]
RUN dotnet restore "src/Boostrapers/CoveragePolygonService.Api/CoveragePolygonService.Api.csproj"
COPY . .
WORKDIR "/src/src/Boostrapers/CoveragePolygonService.Api"
RUN dotnet build "CoveragePolygonService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoveragePolygonService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoveragePolygonService.Api.dll"]