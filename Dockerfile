FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
COPY ["src/Velosaurus.Api/Velosaurus.Api.csproj", "src/Velosaurus.Api/"]
COPY ["src/Velosaurus.DatabaseManager/Velosaurus.DatabaseManager.csproj", "src/Velosaurus.DatabaseManager/"]
RUN dotnet restore "src/Velosaurus.DatabaseManager/Velosaurus.DatabaseManager.csproj"
RUN dotnet restore "src/Velosaurus.Api/Velosaurus.Api.csproj"
COPY . .
RUN dotnet build "src/Velosaurus.Api/Velosaurus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "src/Velosaurus.Api/Velosaurus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Velosaurus.Api.dll"]
