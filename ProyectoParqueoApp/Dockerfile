# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["ProyectoParqueoApp/ProyectoParqueoApp.csproj", "ProyectoParqueoApp/"]
RUN dotnet restore "ProyectoParqueoApp/ProyectoParqueoApp.csproj"
COPY . .
WORKDIR "/src/ProyectoParqueoApp"
RUN dotnet publish -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProyectoParqueoApp.dll"]
