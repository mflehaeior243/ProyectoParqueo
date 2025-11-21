# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Copiamos el .csproj al directorio actual
COPY ["ProyectoParqueoApp.csproj", "./"]
RUN dotnet restore "./ProyectoParqueoApp.csproj"

# Copiamos todo el código
COPY . .
# Establecemos la carpeta de trabajo al proyecto donde está el .csproj
WORKDIR "/src"
RUN dotnet publish "ProyectoParqueoApp.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProyectoParqueoApp.dll"]


