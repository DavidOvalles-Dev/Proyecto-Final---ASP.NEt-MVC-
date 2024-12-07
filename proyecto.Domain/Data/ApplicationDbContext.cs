using Microsoft.EntityFrameworkCore;
using proyecto.Domain.Entities;



namespace proyecto.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<MiembroActividad> MiembroActividades { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de muchos a muchos: Miembro ↔ Actividad
            modelBuilder.Entity<MiembroActividad>()
                .HasKey(ma => new { ma.MiembroId, ma.ActividadId });

            modelBuilder.Entity<MiembroActividad>()
                .HasOne(ma => ma.Miembro)
                .WithMany(m => m.MiembroActividades)
                .HasForeignKey(ma => ma.MiembroId);

            base.OnModelCreating(modelBuilder);
        }

    }
    }
