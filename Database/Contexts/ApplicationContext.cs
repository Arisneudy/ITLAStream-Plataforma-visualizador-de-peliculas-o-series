using Microsoft.EntityFrameworkCore;

namespace ITLAStream.Infrastucture.Persistence.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    
    // Modelos
    public DbSet<Core.Domain.Entities.Series> Series { get; set; }
    public DbSet<Core.Domain.Entities.Productora> Productoras { get; set; }
    public DbSet<Core.Domain.Entities.Genero> Generos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tablas
        #region Tablas
            modelBuilder.Entity<Core.Domain.Entities.Series>().ToTable("Series");
            modelBuilder.Entity<Core.Domain.Entities.Productora>().ToTable("Productoras");
            modelBuilder.Entity<Core.Domain.Entities.Genero>().ToTable("Generos");
        #endregion
        
        // Llaves primarias
        #region Llaves primarias
        modelBuilder.Entity<Core.Domain.Entities.Series>()
            .HasKey(s => s.Id);
        modelBuilder.Entity<Core.Domain.Entities.Productora>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Core.Domain.Entities.Genero>()
            .HasKey(g => g.Id);
        #endregion
        
        // Relaciones
        #region Relaciones
            modelBuilder.Entity<Core.Domain.Entities.Series>()
                .HasOne(p => p.Productora)
                .WithMany(p => p.Serie)
                .HasForeignKey(s => s.ProductoraId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Core.Domain.Entities.Series>()
                .HasOne(g => g.Genero)
                .WithMany(g => g.Serie)
                .HasForeignKey(s => s.GeneroId)
                .OnDelete(DeleteBehavior.Cascade);
        #endregion
        
        // Configuraciones de propiedades
        #region Configuracion de propiedades
            modelBuilder.Entity<Core.Domain.Entities.Genero>()
                .Property(g => g.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Core.Domain.Entities.Genero>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Core.Domain.Entities.Genero>()
                .Property(g => g.Descripcion)
                .HasDefaultValue("");

            modelBuilder.Entity<Core.Domain.Entities.Productora>()
                .Property(p => p.Nombre)
                .HasMaxLength(170)
                .IsRequired();

            modelBuilder.Entity<Core.Domain.Entities.Productora>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Core.Domain.Entities.Productora>()
                .Property(p => p.Descripcion)
                .HasDefaultValue("");
            
            modelBuilder.Entity<Core.Domain.Entities.Series>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
        #endregion
    }
}