FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

ARG PROJECT_PATH
RUN ls -la $PROJECT_PATH        # (debug opcional)
RUN dotnet restore $PROJECT_PATH
RUN dotnet build $PROJECT_PATH -c Release -o /app/build
RUN dotnet publish $PROJECT_PATH -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT []
