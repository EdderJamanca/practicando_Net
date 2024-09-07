using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace primer_api.Models;



public class Categoria {

    [Key]
    public Guid CategoriaId {get;set;}
    [Required]
    [MaxLength]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}
}