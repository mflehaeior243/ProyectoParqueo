# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Copiamos el .csproj directamente desde el root directory
COPY ["./ProyectoParqueoApp.csproj", "./"]
RUN dotnet restore "./ProyectoParqueoApp.csproj"

# Copiamos todo el código
COPY . .
WORKDIR "/src"
RUN dotnet publish -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProyectoParqueoApp.dll"]

