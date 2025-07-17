# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Corrigido aqui 👇
COPY src/MeuBuffet.Api/MeuBuffet.Api.csproj src/MeuBuffet.Api/
RUN dotnet restore src/MeuBuffet.Api/MeuBuffet.Api.csproj

COPY . .
WORKDIR /src/src/MeuBuffet.Api
RUN dotnet build MeuBuffet.Api.csproj -c $BUILD_CONFIGURATION -o /app/build

# Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish MeuBuffet.Api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Execução final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeuBuffet.Api.dll"]
