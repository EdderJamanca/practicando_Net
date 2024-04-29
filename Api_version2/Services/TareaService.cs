using Api_version2.Models;

namespace Api_version2.Services;

public class TareaService:ITareaService
{
    TareasContext context;

    public TareaService(TareasContext dbcontext){
        context = dbcontext;    
    }

    public IEnumerable<Tarea> Get(){
        return context.Tarea;
    }

    public async Task Save(Tarea tarea){
        context.Add(tarea);

        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea){
         
         var tareaActual=context.Tarea.Find(id);

         if(tareaActual!=null){
            tareaActual.Titulo=tarea.Titulo;
            tareaActual.Descripcion=tarea.Descripcion;
            tareaActual.Prioridad=tarea.Prioridad;
            tareaActual.CategoriaId=tarea.CategoriaId;

            await context.SaveChangesAsync();
         }
    }

    public async Task Delete(Guid id){
        var tareaActual=context.Tarea.Find(id);

        if(tareaActual!=null){
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}


public interface ITareaService 
{
    IEnumerable <Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id,Tarea tarea);
    Task Delete(Guid id);
}