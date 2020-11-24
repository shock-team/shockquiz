# ShockQuiz

## Componentes NuGet:
 - System.Web
 - Newtonsoft.Json
 - Entity Framework
 - EntityFramework.SqlServerCompact

## ¿Cómo re-inicializar la base de datos?

1. Eliminar el archivo ShockQuiz.sdf (se encuentra donde está el ejecutable)
2. Eliminar la carpeta Migrations (del proyecto)
3. Abrir la consola del administrador de paquetes (Herramientas>Administrador de paquetes NuGet>Consola del Administrador de paquetes) y ejecutar:
`PM> enable-migrations`
4. Una vez que haya finalizado la re-creación de las tablas, hay que crear la primer migración:
`PM> add-migration init`
5. Por último, enviar los cambios a la base de datos:
`PM> update-database`
