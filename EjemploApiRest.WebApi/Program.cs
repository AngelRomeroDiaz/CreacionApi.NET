using EjemploApiRest.Abstractions;
using EjemploApiRest.Application;
using EjemploApiRest.Repository;
using EjemploApiRest.DataAccess;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuramos la conexion a la base de datos
builder.Services.AddDbContext<ApiDbContex>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("EjemploApiRest.WebApi"));// con esta linea indicamos que la migracion se va a crear en el proyecto EjemploApiRest.WebApi
});
//hacemos inyeccion de dependencias 
builder.Services.AddScoped(typeof(IApplication<>), typeof(Application<>));// con esta linea indicamos que cuando pidamos un interfazApplication nos entregue un objeto instanciado de Application
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>)); // con esta linea indicamos que cuando pidamos un interfazRepocitory nos entregue un objeto instanciado de repositori
builder.Services.AddSingleton(typeof(IDBContext<>), typeof(DbContext<>)); // con esta linea indicamos que cuando pidamos un interfazRepocitory nos entregue un objeto instanciado de repositori

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Si necesita OpenAPI, considere agregar Swashbuckle.AspNetCore o una versión compatible del paquete OpenApi.
// builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
