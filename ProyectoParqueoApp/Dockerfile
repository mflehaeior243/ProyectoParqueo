# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiamos todo el proyecto de una vez
COPY . .

# Restauramos y publicamos desde el mismo directorio
RUN dotnet restore "ProyectoParqueoApp.csproj"
RUN dotnet publish "ProyectoParqueoApp.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProyectoParqueoApp.dll"]




