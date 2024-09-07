// See https://aka.ms/new-console-template for more information


using SuperHeroe.Models;
using System.Text;

//ImprimirInfo 
var imprimirInfo = new ImprimirInfo();
var poderVolar = new SuperPoder();
poderVolar.Nombre = "Volar";
poderVolar.Description = "capacidad para volar y planear en el aire";
poderVolar.Nivel = NivelPoder.NivelDos;

var superFuerza=new SuperPoder();
superFuerza.Nombre = "Super Fuerza";
superFuerza.Nivel=NivelPoder.NivelTrees;

var regeneracion =new SuperPoder();
regeneracion.Nombre = "Regeneración";
regeneracion.Nivel = NivelPoder.NivelDos;

var superman = new SuperHeroes();

superman.Id = 1;
superman.Nombre = "Superman";
superman.IdentidadSecreta = "Clark kent";
superman.Ciudad = "Metropolis";
superman.PuedeVolar = true;


var superman2 = new SuperHeroes();

superman2.Id = 1;
superman2.Nombre = "Superman";
superman2.IdentidadSecreta = "Clark kent";
superman2.Ciudad = "Metropolis";
superman2.PuedeVolar = true;

SuperHeroeRecord superHeroeRecord = new(1, "Superman", "Clark kent");
SuperHeroeRecord superHeroeRecord3 = new(1, "Superman", "Clark kent");

Console.Write(superHeroeRecord == superHeroeRecord3);

List<SuperPoder> PoderSuperman = new List<SuperPoder>();

PoderSuperman.Add(poderVolar);
PoderSuperman.Add(superFuerza);

superman.SuperPoderes = PoderSuperman;
string Rsuperpoderes = superman.UsarSuperPoderes();
Console.WriteLine(Rsuperpoderes);

//seccion anti heroe
var wolverine = new AntiHeroe();
wolverine.Id = 5;
wolverine.Nombre = "Wolverine";
wolverine.IdentidadSecreta = "Logan";
wolverine.PuedeVolar = false;

List<SuperPoder> poderesWolverine = new List<SuperPoder>();
poderesWolverine.Add(regeneracion);
poderesWolverine.Add(superFuerza);

wolverine.SuperPoderes=poderesWolverine;
string resultWolverinePoder = wolverine.UsarSuperPoderes();
Console.WriteLine(resultWolverinePoder);
//Console.WriteLine(resultWol)


string accionAntiheroe = wolverine.RealizarAccionDeAntiheroe("Ataca a la policia ");
Console.WriteLine(accionAntiheroe);
string accionprincipal = wolverine.SalvarElMundo();
Console.WriteLine(accionprincipal);
string salvartierra=wolverine.SalvarTierra();
Console.WriteLine(salvartierra);

imprimirInfo.ImprimirSuperHeroe(wolverine);


public record SuperHeroeRecord(int Id,string Nombre,string IdentidadSecreta)
{

}

//Modificadores de Acceso Vamos a poder asignar quien puede 
//usar nuestras clases o el alcance de las clases en nuestro proyecto. 
//Los modificadores más relevantes y que mas se utilizan son los siguientes: 
    
// Public Exponemos los métodos y propiedades de la clase para que puedan ser
// utilizados por cualquiera que este creando objetos con nuestra clase. 
// El acceso no está restringido.

// Protected El acceso esta limitado a la clase contenedora o a los tipos 
//    derivados de la clase contenedora. Garantizamos que las clases
//    que hereden de esta clase también lo puedan utilizar. 

//Internal el acceso está limitado al ensamblado actual. 
//    Es comun en C# tiener muchos proyectos que se referencien a otors, 
//    asi aseguramos que la clase solo sea utilizada por nuestro proyecto 
//    internamente. 

//Private Evitamos que cualquiera que este fuera del contexto de nuestra 
//    clase pueda utilizar los métodos o propiedades de la clase. 
//    El acceso está limitado al tipo contenedor. 

//Private Protected El acceso está limitado a la clase contenedora o a los
//    tipos derivados de la clase contenedora que hay en el ensamblado actual 
//    Protected internal El acceso está limitado al ensamblado actual
//    o a los tipos derivados de la clase contenedora.