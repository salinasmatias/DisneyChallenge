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

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    Name = "Admin",
                    Description = "Admin Role"
                },
                new Role
                {
                    RoleId = 2,
                    Name = "User",
                    Description = "User Role"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "Alkymer",
                    Email = "Alkymer@alkemy.com",
                    Password = "1234",
                    RoleId = 1
                },
                new User
                {
                    UserId = 2,
                    Username = "Test",
                    Email = "test@test.com",
                    Password = "test",
                    RoleId = 2
                },
                new User
                {
                    UserId = 3,
                    Username = "Test2",
                    Email = "test2@test.com",
                    Password = "test",
                    RoleId = 2
                }
            );

        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<PersonajePelicula> PersonajePeliculas { get; set; }
    }
}
