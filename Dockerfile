ARG VERSION="3.1-alpine"

FROM mcr.microsoft.com/dotnet/core/aspnet:$VERSION AS base
WORKDIR /app
EXPOSE 6000

ENV ASPNETCORE_URLS=http://*:6000
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/core/sdk:$VERSION AS build
WORKDIR /src

COPY ./src/Microservice.Whatevers.Domain/*.csproj ./Microservice.Whatevers.Domain/
COPY ./src/Microservice.Whatevers.Repositories/*.csproj ./Microservice.Whatevers.Repositories/
COPY ./src/Microservice.Whatevers.Services/*.csproj ./Microservice.Whatevers.Services/
COPY ./src/Microservice.Whatevers.WebApi/*.csproj ./Microservice.Whatevers.WebApi/

RUN dotnet restore ./Microservice.Whatevers.WebApi

COPY ./src/Microservice.Whatevers.Domain/. ./Microservice.Whatevers.Domain/
COPY ./src/Microservice.Whatevers.Repositories/. ./Microservice.Whatevers.Repositories/
COPY ./src/Microservice.Whatevers.Services/. ./Microservice.Whatevers.Services/
COPY ./src/Microservice.Whatevers.WebApi/. ./Microservice.Whatevers.WebApi/

WORKDIR /src/Microservice.Whatevers.WebApi/
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Whatevers.WebApi.dll"]