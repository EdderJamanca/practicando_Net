using apifluent;
using apifluent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TareasCantext>(builder.Configuration.GetConnectionString("cnTareas"));
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion",async ([FromServices] TareasCantext DbContext)=>{
  DbContext.Database.EnsureCreated();
  return Results.Ok("Base de datos en memoria: "+ DbContext.Database.IsInMemory());
});

// obtener el listado de tarea
app.MapGet("/api/tareas",async([FromServices] TareasCantext dato)=>{
     return Results.Ok(dato.Tareas.Include(p=>p.Categoria));
});
// registrar Tarea

app.MapPost("/api/tarea", async ([FromServices] TareasCantext data,[FromBody] Tareas tarea)=>{

     tarea.TareaId=Guid.NewGuid();
     tarea.FechaCreacion=DateTime.Now;

     await data.AddAsync(tarea);

     await data.SaveChangesAsync();

     return Results.Ok("La Tarea fue registrada correctamente");
});

// actualizar un registro

app.MapPut("/api/tarea/{id}", async ([FromServices] TareasCantext data, [FromBody] Tareas tarea,[FromRoute] Guid id)=>{

  var tareaActual=data.Tareas.Find(id);
    
    if(tareaActual!=null){
        tareaActual.CategoriaId=tarea.CategoriaId;
        tareaActual.Titulo=tarea.Titulo;
        tareaActual.PrioridadTarea=tarea.PrioridadTarea;
        tareaActual.Description=tarea.Description;

        await data.SaveChangesAsync();

        return Results.Ok("Se actualizo con exito la Tarea selecciono");
    }

    return Results.NotFound();

});

app.MapDelete("/api/tareas/{id}",async ([FromServices] TareasCantext data, [FromRoute] Guid id)=>{

   var tareaActual=data.Tareas.Find(id);

   if(tareaActual!=null){

      data.Remove(tareaActual);
      await data.SaveChangesAsync();
      return Results.Ok("Se elimino Correctamente");
      
   }

   return Results.NotFound("Error en el servidor");
});

app.Run();


// migracionn
// dotnet ef migrations add InitialCreate --se crearon los archivos de migration
// dotnet ef database update -> nos permite crear tablas o modificarlas

// dotnet ef migrations add InitialData