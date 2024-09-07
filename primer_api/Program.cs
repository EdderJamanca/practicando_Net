using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primer_api;
using primer_api.Models;
var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDB"));

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion",async([FromServices] TareasContext dbconexion)=>{
    dbconexion.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria "+dbconexion.Database.IsInMemory());
});


app.MapGet("api/tareas",async ([FromServices] TareasContext  dbconexion) =>{
    return Results.Ok(dbconexion.Tarea.Include(p=>p.Categoria));
});


app.MapPost("api/tarea",async([FromServices] TareasContext dbconexion,[FromBody] Tarea tarea)=>{
        tarea.TareaId =Guid.NewGuid();
        tarea.FechaCreacion=DateTime.Now;
        await dbconexion.AddAsync(tarea);
        await dbconexion.SaveChangesAsync();
        return Results.Ok("se registro correctamente");   
});

app.MapPut("api/tarea/{id}",async([FromServices] TareasContext dbconexion,[FromBody] Tarea tarea,[FromRoute] Guid id)=>{

    var tareaActual=dbconexion.Tarea.Find(id);

    if(tareaActual!=null){
        tareaActual.CategoriaId=tarea.CategoriaId;
        tareaActual.Titulo=tarea.Titulo;
        tareaActual.Prioridad=tarea.Prioridad;
        tareaActual.Descripcion=tarea.Descripcion;

        await dbconexion.SaveChangesAsync();

        return Results.Ok("Se actualizo correctamente");
    }

    return Results.NotFound();
});


app.MapDelete("api/tarea/{id}",async([FromServices] TareasContext dbconexion,[FromRoute] Guid id)=>{
        var tareaActual=dbconexion.Tarea.Find(id);

        if(tareaActual!=null){
            dbconexion.Remove(tareaActual);
            await dbconexion.SaveChangesAsync();
            return Results.Ok("se elimino correctamente");
        }
        
        return Results.BadRequest();
});

app.Run();
// 
// llibrerias 
