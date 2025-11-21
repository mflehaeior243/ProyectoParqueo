using Microsoft.EntityFrameworkCore;
using ProyectoParqueo.Models;

namespace ProyectoParqueo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.Property(v => v.Placa)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(v => v.Marca)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(v => v.Modelo)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(v => v.Color)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.Property(v => v.Estado)
                      .IsRequired()
                      .HasMaxLength(20)
                      .HasDefaultValue("Dentro");

                entity.Property(v => v.Regalo)
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasDefaultValue("N/A");

                entity.Property(v => v.HorasTotal)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired()
                      .HasDefaultValue(0);

                entity.Property(v => v.HoraEntrada)
                      .HasColumnType("datetime2")
                      .IsRequired(false);

                entity.Property(v => v.HoraSalida)
                      .HasColumnType("datetime2")
                      .IsRequired(false);
            });
        }
    }
}
