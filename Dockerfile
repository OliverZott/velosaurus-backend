FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . .
RUN dotnet restore "src/Velosaurus.Api/Velosaurus.Api.csproj"
RUN dotnet build "src/Velosaurus.Api/Velosaurus.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Velosaurus.Api/Velosaurus.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Velosaurus.Api.dll"]
