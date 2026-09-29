# Microservice

## Ejecución local con .NET Aspire

1. Inicia Docker Desktop.
2. Desde la raíz de la solución, ejecuta `dotnet run --project Microservice.AppHost`.
3. Abre el dashboard que indique la consola. El recurso `microservice-api` publica Swagger en `/swagger`.

El AppHost crea SQL Server en Docker con un volumen persistente e inyecta en la API la cadena `ConnectionStrings__LocalConnection`; no se usa la instancia local de SQL Express.

## Ejecución sólo con Docker Compose

Define opcionalmente `MSSQL_SA_PASSWORD` (debe cumplir la política de SQL Server) y ejecuta `docker compose up --build` desde la raíz. Swagger queda disponible en `http://localhost:8080/swagger`.
