1.-Se puede iniciar desde el boton de IIS Express o entrar en Package Manager Cosole y ejecutar en comando Dotnet run

2.-Correr la migración Package Manager ConsoleAdd-Migration DatabaseCreation
	Se crea y prepara la migración de la base de datos en el proyecto
3.-Correr el update de la bae de datos Update-Database
	Crea la base de datos
4.- Correr Add-Migration InitialData Add-Migration InitialData
	Inserta los datos precargados, que se encuentran en el proyecto en la parte de Entities/configuración
5.-Esta lista para usarse 