
Donas una aplicación ASP:NET Core Web APIdesarrollada con ASP.NET Core 8.0 [Documentación oficial de .NET 8](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0) que implementa un sistema de gestión con funcionalidades CRUD, 
Autenticación de usuarios, migraciones automáticas y siembra de datos iniciales.

Características Principales
- Migraciones automáticas de base de datos
- Siembra de datos iniciales (sucursales y estados de órdenes)
- Arquitectura MVC con separación de responsabilidades


Tecnologías Utilizadas

- .NET Framework/Core (8.0)
- ASP.NET MVC
- Entity Framework
- SQL Server
- LINQ
- Se implementaron: AutoMapper, ASP.NET Identity y un sistema de logging personalizado.

Requisitos Previos

- Visual Studio 2022 o superior
- .NET SDK [8.0]
- SQL Server o LocalDB
- Git

Instalación Local
Sigue estos pasos para configurar el proyecto:

1. Obtener el còdigo fuente:  
   - Recibirás los archivos del proyecto por correo electrónico
   - Descomprime el archivo ZIP en tu directorio de trabajo

    o en caso de que recibir informaciòn de repositorio git: 
   - git clone https://github.com/tu-usuario/tu-repositorio.git
   - cd tu-repositorio

2. Abre el proyecto en Visual Studio.
  
3. Restaura los paquetes NuGet:
    - Menú Herramientas > Administrador de paquetes NuGet > Restaurar paquetes.

4. Configura la cadena de conexión e información del cliente en el archivo appsettings.json
  "ConnectionStrings": {
    "DefaultConnection": "Server=TUSERVIDOR;Database=TUBASEDEDATOS;User Id = TUUSUARIO;Password=TUCONTRASEÑA;TrustServerCertificate=True;"
  }
  - Configurar url del cliente
  "UrlApi": "https://www.urlcliente.com"


Estructura del proyecto: 
El proyecto contiene 4 proyectos: 

├── Krispy.AccessData     # Contiene el contexto de base de datos (DbContext), repositorios y migraciones de Entity Framework.
├── Krispy.Api            # Proyecto principal. Aloja los controladores, configuraciones de servicios y endpoints.
├── Krispy.Models         # Define las clases de dominio y DTOs usados a lo largo de la aplicación.
├── Krispy.Utils          # Contiene funciones auxiliares, servicios comunes y clases de utilidad compartidas.


Estructura del proyecto principal: 

├── Controllers/        # Controladores MVC
├── appsettings.json    # Configuración de la aplicación
├── Program.cs

Autor
Yareni Guadalupe Muñoz Galicia