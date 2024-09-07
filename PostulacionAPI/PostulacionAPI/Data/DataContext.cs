using Microsoft.EntityFrameworkCore;

namespace PostulacionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Job> Job { get; set; }

        public DbSet<JobType> JobType { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Trabajo> Trabajo { get; set; }

        public DbSet<Postular> Postular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajo>(entity =>
            {
                // Configurar el tipo de columna como decimal(18, 5)
                entity.Property(e => e.Salario)
                    .HasColumnType("decimal(18, 5)"); // Dos dígitos decimales

                // Otros mapeos para las otras propiedades
                // ...

            });

            modelBuilder.Entity<Postular>(entity =>
            {
                entity.Property(e => e.Archivo)
                    .HasColumnType("varbinary(max)");
            });
        }
    }
}
