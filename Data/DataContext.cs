using EcoTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Leitura> Leituras { get; set; }
        public DbSet<Energia> Energias { get; set; }
        public DbSet<Agua> Aguas { get; set; }
        public DbSet<Residuo> Residuos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Recurso>().ToTable("Recursos");
            modelBuilder.Entity<Energia>().ToTable("Energias");
            modelBuilder.Entity<Agua>().ToTable("Aguas");
            modelBuilder.Entity<Residuo>().ToTable("Residuos");

            modelBuilder.Entity<Recurso>()
                .HasMany(r => r.Leituras)
                .WithOne(l => l.Recurso)
                .HasForeignKey(l => l.RecursoId)
                .OnDelete(DeleteBehavior.Cascade); // Apagou o recurso, some as leituras
        }
    }
}