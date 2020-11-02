# README.MD
WebApiCuentas
=======
Notas sobre la aplicacion

Contenido
-----------
La solucion contiene un proyecto web **WebApi** desarrollado con Visual Studio 2017 Community, con plantilla Api .Net Core 2.0 en lenguaje C#


Base de Datos
-----------
El proyecto web **WebApi** contiene la base de datos de tipo SqLite en el archivo **Cuentas.s3db**

La capa de **DataAccess** usa Entity Framework y linq para el acceso a los datos (no hay que hacer migraciones desde el codigo ni configuraciones)


Modelo de Datos 
-----------
El modelo tiene una entidad llamada **Usuario** y estas es su definicion:
![](/modelo.jpg)

Datos 
-----------
La tabla usuarios contiene dos registros de usuario, un administrador y un usuario comun
![](/datos.jpg)

Api
-----------
El Api contiene los controladores;
* api/Login: para la autenticacion
* api/Usuarios: para el manejo de los datos de los usuarios

Como metodo de autenticacion se usa JWT para la autenticacion basada en tokens 

**api/Login** contiene el metodo para validar usuario y password, y devuelve el token

para hacer las peticiones a **api/Usuarios** se usa el token devuelto anteriormente al iniciar sesion

**api/Usuarios** esta securizado y sus metodos autorizan la accion basada en claims

Pruebas
-----------
El proyecto web contiene la configuracion de Swagger para hacer ls peticiones http y se debe visualizar la interfaz al lanzar la aplicacion en
[http://localhost:23951/swagger/index.html]
