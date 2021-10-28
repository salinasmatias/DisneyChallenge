using DisneyWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisneyWorld.AccessData
{
    public class DisneyWorldContext : DbContext
    {
        public DisneyWorldContext()
        {
        }

        public DisneyWorldContext(DbContextOptions<DisneyWorldContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.GeneroId);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(e => e.Genero)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.GeneroId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Personaje>(entity =>
            {
                entity.Property(e => e.Historia)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(2083)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonajePelicula>(entity =>
            {
                entity.HasKey(pp => new { pp.PeliculaId, pp.PersonajeId });

                entity.HasOne(pp => pp.Pelicula)
                      .WithMany(pelicula => pelicula.PersonajePeliculas)
                      .HasForeignKey(pp => pp.PeliculaId);

                entity.HasOne(pp => pp.Personaje)
                      .WithMany(personaje => personaje.PersonajePeliculas)
                      .HasForeignKey(pp => pp.PersonajeId);
            });
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<PersonajePelicula> PersonajePeliculas { get; set; }
    }
}
