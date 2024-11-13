//using Invetory_for_home_WEB_API.ver.Models;
using Invetory_for_home_WEB_API.ver.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura la cadena de conexi�n desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar el DbContext con la cadena de conexi�n
builder.Services.AddDbContext<InventoryForHomeContext>(options =>
    options.UseSqlServer(connectionString));

// Agregar controladores y otros servicios

// Add services to the container.

// A�adir servicios al contenedor.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()  // Permitir cualquier origen
               .AllowAnyMethod()  // Permitir cualquier m�todo (GET, POST, etc.)
               .AllowAnyHeader(); // Permitir cualquier encabezado
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
////A�adir el contexto para poder usarlo
//builder.Services.AddDbContext<InventoryForHomeContext>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
