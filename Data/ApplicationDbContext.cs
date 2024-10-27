using Microsoft.EntityFrameworkCore;
using ApiMigracion.Models;

namespace ApiMigracion.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
    }
}
