using Microsoft.EntityFrameworkCore;
using ProyectoAudisoft.Api.Models;

namespace ProyectoAudisoft.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Nota> Notas { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nota>()
                .Property(n => n.Valor)
                .HasPrecision(5, 2);
        }


    }
}
