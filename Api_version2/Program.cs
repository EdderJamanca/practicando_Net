using Api_version2;
// using Api_version2.Service;
using Api_version2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnnTarea"));

builder.Services.AddScoped<ITareaService,TareaService>();
builder.Services.AddScoped<ICategoriaService,CategoriaService>();

builder.Services.AddCors(option=>{
    option.AddPolicy("cors",app=>{
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("cors");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

