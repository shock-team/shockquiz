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

## ¿Cómo jugar si la base de datos está vacia?
1. Al iniciar Shock!Quiz, ingrese nombre de usuario y contraseña y presione en **Registro**, esto creará el primer usuario con permisos de Administrador.
2. Una vez que esté logeado, vaya a **Configuración**.
3. En el apartado de _Añadir Conjunto_, en el campo Nombre ingrese **OpenTDB**, en tiempo esperado por pregunta lo que desee y marque "Pedir Token". Por último, presione **Añadir**.
4. Una vez creado el conjunto de preguntas, en el apartado _Añadir Preguntas_ seleccione OpenTDB e ingrese la cantidad de preguntas que desea agregar a la base de datos (1000 recomendado).
5. Cuando se hayan terminado de descargar las preguntas (puede tardar un momento) ya está listo para poder jugar.
