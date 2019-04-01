using Microsoft.EntityFrameworkCore;

namespace C8ProyectoFinalPorEquipos.Models
{
  public class SqliteDbContext : DbContext
  {
    public DbSet<PacienteViewModel> Pacientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data source=Db/consultorio.db");
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<PacienteViewModel>(p =>
      {
        p.HasData(
            new PacienteViewModel { Id = 1, Nombre = "Bidkar", Apellidos = "Aragon", Edad = 39, Genero = "Masculino" }
        );
      });
      base.OnModelCreating(modelBuilder);
    }
  }
}