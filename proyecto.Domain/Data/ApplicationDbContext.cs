using Microsoft.EntityFrameworkCore;
using proyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Domain.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("\"Server=(localdb)\\\\MSSQLLocalDB;Database=nProyectoFinal2DB;Trusted_Connection=True;\";");
            }
        }

        public DbSet<Cliente> Clientes { get; set; }
        // Agrega DbSets adicionales según las tablas requeridas.
    }
}
