using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Productora> Productoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Tablas"
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            #endregion

            #region "Primary Key"
            modelBuilder.Entity<Serie>().HasKey(s => s.Id);
            modelBuilder.Entity<Genero>().HasKey(g => g.Id);
            modelBuilder.Entity<Productora>().HasKey(p => p.Id);

            
            modelBuilder.Entity<Serie>().Property(s => s.Id)
                .UseIdentityColumn();
            modelBuilder.Entity<Genero>().Property(g => g.Id)
                .UseIdentityColumn();
            modelBuilder.Entity<Productora>().Property(p => p.Id)
                .UseIdentityColumn();
            #endregion

            #region relationships     
            modelBuilder.Entity<Productora>()
                .HasMany<Serie>(p => p.Series)
                .WithOne(s => s.Productora)
                .HasForeignKey(s => s.IdProductora)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.Genero)
                .WithMany(g => g.Series)
                .HasForeignKey(s => s.IdGeneroPrimario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(s => s.GeneroSecundario)
                .WithMany()
                .HasForeignKey(s => s.IdGeneroSecundario)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region "property configuration"

            modelBuilder.Entity<Productora>()
                .HasMany(p => p.Series)
                .WithOne(s => s.Productora)
                .HasForeignKey(s => s.IdProductora)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(g => g.Genero)
                .WithMany(s => s.Series)
                .HasForeignKey(s => s.IdGeneroPrimario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Serie>()
                .HasOne(g => g.GeneroSecundario)                
                .WithMany()
                .HasForeignKey(s => s.IdGeneroSecundario)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Serie>()
                .Property(s => s.Nombre)
                .IsRequired()
                .HasMaxLength(255); 

            modelBuilder.Entity<Serie>()
                .Property(s => s.UrlPortada)
                .IsRequired();

            modelBuilder.Entity<Serie>()
                .Property(s => s.UrlVideo)
                .IsRequired();

            modelBuilder.Entity<Productora>()
                .Property(p => p.Nombre)
                .IsRequired();

            modelBuilder.Entity<Genero>()
                .Property(g => g.Nombre)
                .IsRequired();

            #endregion
        }


    }
}
