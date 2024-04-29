using Humanizer;
// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


Console.WriteLine("Por favor ingrese un nombre");

var nombre=Console.ReadLine();
Console.WriteLine("Por favor ingrese su cargo");
var cargo=Console.ReadLine();

Console.WriteLine("Por favor ingrese su edad");
var edad=int.Parse(Console.ReadLine());


Console.WriteLine($"Mi nombre es {nombre}, mi cargo es {cargo} y tengo edad de {edad.ToWords(new System.Globalization.CultureInfo("es"))}");



// dotnet restore 
// dotnet run -> nos permite ejecutar la aplicacion
// dotnet buil -> nos permite compilar la aplicacion y encontrar los erroes en nuestro codigo
// dotnet  watch run --> la aplicacion va estar esperando cambios en la aplicacion
// dotnet new [nombre del  tipo de proyecto a crear]  -->nos permite crear una aplicacion
// dotnet new --list   -> nos lista los tipos de proyectos que se puede crear
// dotnet clean -> nos limpia ña caprta bin

// > dotnet buil --configuration release   -- Prepara la aplicación para que esté lista en producción, tenga un mejor performance y rendimiento, además de que sea mucho más liviano. Elimina todos los archivos que no se necesitan en producción.

// dotnet new globaljson -> son permite crear un archivo json que es para configuración
// nos permite crear aplicaciones excluir los realease no oficiales 
// nos permite indicar la version del sdk

// nuget.org -> es el npm delos frontend