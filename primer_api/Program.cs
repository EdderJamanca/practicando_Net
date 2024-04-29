using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primer_api;

var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDB"));

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion",async([FromServices] TareasContext dbconexion)=>{
    dbconexion.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria "+dbconexion.Database.IsInMemory());
});

app.Run();
// 
// llibrerias 
