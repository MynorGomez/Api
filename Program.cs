using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Obtener cadena de conexión
string? cadena = builder.Configuration.GetConnectionString("DefaultConnection") 
                 ?? "server=localhost;database=db_empresa1;user=root;password=Minato15@;";

// ✅ Registrar DbContext con versión automática de MySQL
builder.Services.AddDbContext<Conexiones>(opt =>
    opt.UseMySql(cadena, ServerVersion.AutoDetect(cadena))); // 👈 aquí está la corrección

// Agregar controladores
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configurar entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
