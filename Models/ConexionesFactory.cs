using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ApiEmpresa.Models
{
    // Fábrica usada en tiempo de diseño por las herramientas (scaffolding, migrations)
    public class ConexionesFactory : IDesignTimeDbContextFactory<Conexiones>
    {
        public Conexiones CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Conexiones>();
            // Usamos la misma base en memoria que en Program.cs para que el contexto se construya correctamente
            optionsBuilder.UseInMemoryDatabase("TodoList");

            return new Conexiones(optionsBuilder.Options);
        }
    }
}
