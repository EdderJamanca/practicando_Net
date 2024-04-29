using apifluent.Models;
using Microsoft.EntityFrameworkCore;

namespace apifluent;

public class TareasCantext:DbContext
{
    public DbSet<Categoria> Categoria { get; set;}
    public DbSet<Tareas> Tareas{get;set;}

    public TareasCantext(DbContextOptions<TareasCantext> options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        List<Categoria> categoriasInt=new List<Categoria>();
        categoriasInt.Add(new Categoria() { CategoriaId=Guid.Parse("f86031eb-72b9-4d84-83ff-4bb9f6fc93ee"),Nombre="Actividades pendientes",Peso=20});
        categoriasInt.Add(new Categoria() { CategoriaId=Guid.Parse("f86031eb-72b9-4d84-83ff-4bb9f6fc9312"),Nombre="Actividades personales",Peso=50});

        modelBuilder.Entity<Categoria>(categoria=>{

            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);

            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Description).IsRequired(false);
            categoria.Property(p=>p.Peso);

            categoria.HasData(categoriasInt);
        });

        modelBuilder.Entity<Tareas>(tarea=>{

            List<Tareas> tareasInit=new List<Tareas>();

            tareasInit.Add(new Tareas(){TareaId=Guid.Parse("f86031eb-72b9-4d84-83ff-4bb9f6fc9310"),CategoriaId=Guid.Parse("f86031eb-72b9-4d84-83ff-4bb9f6fc93ee"),PrioridadTarea=Prioridad.Media,Titulo="Pago de servicios",FechaCreacion=DateTime.Now});
            tareasInit.Add(new Tareas(){TareaId=Guid.Parse("f86031eb-72b9-4d84-83ff-4bb9f6fc9410"),CategoriaId=Guid.Parse("f86031eb-72b9-4d84-83ff-4bb9f6fc9312"),PrioridadTarea=Prioridad.Media,Titulo="Pago de servicios",FechaCreacion=DateTime.Now});

            tarea.ToTable("Tarea");
            
            tarea.HasKey(p=>p.TareaId);

            tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);

            tarea.Property(p=>p.Description).IsRequired(false);

            tarea.Property(p=>p.PrioridadTarea);

            tarea.Property(p=>p.FechaCreacion);

            tarea.Ignore(p=>p.Resumen);

            tarea.HasData(tareasInit);
        });
        // base.ConfigureConventions(configurationBuilder);
    }
}