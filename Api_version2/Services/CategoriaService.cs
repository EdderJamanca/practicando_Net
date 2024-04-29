using Api_version2.Models;
namespace Api_version2.Services;


public class CategoriaService:ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext){
        context=dbcontext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categoria;
    }    // public Guid CategoriaId {}

    public async Task Save(Categoria categoria){
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,Categoria categoria){

        var categoriaActual=context.Categoria.Find(id);
        if(categoriaActual!=null){
            categoriaActual.Nombre=categoria.Nombre;
            categoriaActual.Descripcion=categoria.Descripcion;
            categoriaActual.Peso=categoria.Peso;

            await context.SaveChangesAsync();
        }
      
    }


    public async Task Delete (Guid id){
        

        var categoriaActual=context.Categoria.Find(id);

        if(categoriaActual!=null){
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }

}


public interface  ICategoriaService
{
    IEnumerable<Categoria> Get();   
    Task Save(Categoria categoria);
    Task Update(Guid id,Categoria categoria);

    Task Delete(Guid id);
}