using Microsoft.EntityFrameworkCore;
using primer_api.Models;

namespace primer_api;

public class TareasContext:DbContext
{


    public DbSet<Categoria> Categoria {get;set;}

    public DbSet<Tarea> Tarea {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options):base(options){

    }

}