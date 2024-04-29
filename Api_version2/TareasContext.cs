using Microsoft.EntityFrameworkCore;
using Api_version2.Models;

namespace Api_version2;


public class  TareasContext:DbContext
{

    public DbSet<Categoria> Categoria {get;set;}

    public DbSet<Tarea> Tarea {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}
    // public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriaInit=new List<Categoria>();

        categoriaInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Nombre = "Actividades pendientes", Peso = 20});
        categoriaInit.Add(new Categoria() { CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Nombre = "Actividades personales", Peso = 50});
        // base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Categoria>(categoria=>{
            categoria.ToTable("Categoria");

            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Descripcion).IsRequired(false);
            categoria.Property(p=>p.Peso);

            categoria.HasData(categoriaInit);
        });

        List<Tarea> tareaInit=new List<Tarea>();

        tareaInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Prioridad = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now });
        tareaInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), CategoriaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Prioridad = Prioridad.Baja, Titulo = "Terminar de ver pelicula en netflix", FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Tarea>(tarea=>{
            tarea.ToTable("Tarea");
            tarea.HasKey(p=>p.TareaId);
            tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tarea).HasForeignKey(p=>p.CategoriaId);
            tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=>p.Descripcion).IsRequired(false);
            tarea.Property(p=>p.Prioridad);
            tarea.Property(p=>p.FechaCreacion).IsRequired();
            tarea.Ignore(p=>p.Resumen);

            tarea.HasData(tareaInit);
        });

    }

}