# Directrices para generación de código

Estas reglas se aplican a cualquier cambio generado por IA o realizado por colaboradores. Prioriza código sencillo, mantenible, probado y alineado con la arquitectura existente.

## Arquitectura y dependencias

- Mantén la dirección de dependencias: `Api` puede depender de `DomainService`, `EF` y `Entities`; `DomainService` depende de las abstracciones y del dominio; `EF` implementa infraestructura; `Entities` no depende de capas externas.
- No expongas entidades de persistencia directamente desde la API. Usa DTOs o modelos de contrato en los límites HTTP.
- Define las interfaces de repositorios y servicios en el dominio o en una capa de contratos; las implementaciones pertenecen a infraestructura.
- No añadas dependencias de Entity Framework, HTTP, archivos, reloj del sistema o configuración a entidades y reglas de dominio.
- Evita lógica de negocio en controladores, repositorios o clases `Startup`/`Program`. Los controladores sólo validan la entrada, delegan y devuelven una respuesta HTTP.
- Usa inyección de dependencias. No instancies dependencias de infraestructura con `new` dentro de servicios de aplicación.

## DDD

- Da prioridad al lenguaje ubicuo del negocio: nombres claros de agregados, entidades, objetos de valor, comandos y casos de uso.
- Protege invariantes dentro del agregado. Una operación que deja el agregado inválido debe fallar antes de persistir.
- Usa objetos de valor para conceptos sin identidad propia y hazlos inmutables cuando sea posible.
- Modifica un agregado desde su raíz; no expongas colecciones mutables para que otras capas alteren su estado.
- Los repositorios trabajan con agregados, no con tablas ni detalles de ORM.
- Las validaciones de formato y transporte van en la API; las reglas de negocio y las invariantes van en el dominio.

## SOLID

- Una clase debe tener una única responsabilidad y un motivo claro para cambiar.
- Extiende mediante composición o nuevas implementaciones de interfaces; evita modificar bloques condicionales extensos para cada caso nuevo.
- Las implementaciones deben respetar el contrato de sus interfaces, incluidos errores, valores nulos y efectos secundarios.
- Prefiere interfaces pequeñas y específicas del caso de uso.
- Depende de abstracciones en los casos de uso; las dependencias concretas se registran en el arranque.

## Clean Code

- Usa nombres que expresen intención. Evita abreviaturas ambiguas, nombres genéricos (`Manager`, `Helper`, `Utils`) y prefijos técnicos innecesarios.
- Mantén métodos cortos y con un único nivel de abstracción. Extrae métodos privados cuando mejoren la lectura.
- Evita duplicación; extrae una abstracción sólo cuando exista una variación real y estable.
- No uses valores mágicos: conviértelos en constantes con nombre, configuración tipada u objetos de valor.
- Prefiere guard clauses a anidaciones profundas.
- No captures excepciones para ignorarlas. Registra el contexto útil y devuelve o propaga un error coherente.
- Evita comentarios que repiten el código. Documenta decisiones no evidentes, restricciones externas o reglas de negocio.
- Mantén `nullable` habilitado y no suprimas advertencias sin una justificación concreta.

## API y persistencia

- Diseña endpoints REST coherentes: verbos HTTP correctos, códigos de estado precisos y contratos estables.
- Valida solicitudes antes de ejecutar el caso de uso y devuelve errores de validación estructurados.
- Usa operaciones asíncronas para E/S y propaga `CancellationToken` desde el endpoint hasta la infraestructura cuando aplique.
- No incluyas secretos, cadenas de conexión o credenciales en código ni en `appsettings.json` versionado. Usa variables de entorno o secretos de desarrollo.
- Evita `EnsureCreated` en entornos productivos; aplica migraciones controladas para cambios de esquema.

## Pruebas y calidad

- Añade o actualiza pruebas cuando cambie una regla de negocio, un caso de uso o un contrato HTTP.
- Prueba el dominio sin base de datos ni red. Usa pruebas de integración para repositorios, migraciones y endpoints relevantes.
- Una corrección de bug debe incluir una prueba que falle antes de la corrección cuando sea razonable.
- Antes de finalizar, ejecuta `dotnet build Microservice.sln` y las pruebas afectadas.

## Cambios generados por IA

- Inspecciona primero las convenciones y contratos existentes. No reescribas archivos ajenos al objetivo solicitado.
- Propón el cambio mínimo que resuelva el problema; evita refactorizaciones masivas no solicitadas.
- No inventes requisitos de negocio. Señala las suposiciones que afecten al comportamiento.
- No agregues paquetes, servicios externos ni telemetría sin una necesidad explícita y justificada.
- Explica brevemente qué archivos cambian, cómo se verificó el resultado y cualquier limitación pendiente.
