using Microsoft.EntityFrameworkCore;

namespace Database.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    
    // Modelos
    public DbSet<Models.Series> Series { get; set; }
    public DbSet<Models.Productora> Productoras { get; set; }
    public DbSet<Models.Genero> Generos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tablas
        #region Tablas
            modelBuilder.Entity<Models.Series>().ToTable("Series");
            modelBuilder.Entity<Models.Productora>().ToTable("Productoras");
            modelBuilder.Entity<Models.Genero>().ToTable("Generos");
        #endregion
        
        // Llaves primarias
        #region Llaves primarias
        modelBuilder.Entity<Models.Series>()
            .HasKey(s => s.Id);
        modelBuilder.Entity<Models.Productora>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Models.Genero>()
            .HasKey(g => g.Id);
        #endregion
        
        // Relaciones
        #region Relaciones
            modelBuilder.Entity<Models.Series>()
                .HasOne(p => p.Productora)
                .WithMany(p => p.Serie)
                .HasForeignKey(s => s.ProductoraId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Series>()
                .HasOne(g => g.Genero)
                .WithMany(g => g.Serie)
                .HasForeignKey(s => s.GeneroId)
                .OnDelete(DeleteBehavior.Cascade);
        #endregion
        
        // Configuraciones de propiedades
        #region Configuracion de propiedades
            modelBuilder.Entity<Models.Genero>()
                .Property(g => g.Nombre)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Models.Genero>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Models.Genero>()
                .Property(g => g.Descripcion)
                .HasDefaultValue("");

            modelBuilder.Entity<Models.Productora>()
                .Property(p => p.Nombre)
                .HasMaxLength(170)
                .IsRequired();

            modelBuilder.Entity<Models.Productora>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Models.Productora>()
                .Property(p => p.Descripcion)
                .HasDefaultValue("");
            
            modelBuilder.Entity<Models.Series>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
        #endregion
    }
}