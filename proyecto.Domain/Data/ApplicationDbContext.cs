using Microsoft.EntityFrameworkCore;
using proyecto.Domain.Entities;

namespace proyecto.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProyectoFinalP-2;Trusted_Connection=True;",
                        b => b.MigrationsAssembly("proyecto.Domain"));  // Asegúrate de que el nombre del ensamblaje sea correcto
            }
        }
    }

}

