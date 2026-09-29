# Build from the solution root: docker build -f Microservice.Api/Dockerfile .
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Microservice.Api/Microservice.Api.csproj Microservice.Api/
COPY Microservice.DomainService/Microservice.DomainService.csproj Microservice.DomainService/
COPY Microservice.EF/Microservice.EF.csproj Microservice.EF/
COPY Microservice.Entities/Microservice.Domain.csproj Microservice.Entities/
RUN dotnet restore Microservice.Api/Microservice.Api.csproj

COPY . .
RUN dotnet publish Microservice.Api/Microservice.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Api.dll"]
