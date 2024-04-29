using System.Text.Json.Serialization;

namespace apifluent.Models;


public class Categoria {
     public Guid CategoriaId {get; set;}

     public string Nombre {get;set;}

     public string Description {get;set;}

     public int Peso {get;set;}

     [JsonIgnore]
     public virtual ICollection<Tareas> Tareas {get; set;}
     
}

