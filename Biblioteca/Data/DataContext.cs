using Biblioteca.Configuration;
using Biblioteca.DTO;
using Biblioteca.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class DataContext : IdentityDbContext<UserLogin>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (!options.IsConfigured)

            {

                options.UseSqlServer("A FALLBACK CONNECTION STRING");

            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserLogin>()
            .Property(b => b.VehiculoId)
            .HasDefaultValue(1);
            modelBuilder.Entity<UserLogin>()
            .Property(b => b.CiudadId)
            .HasDefaultValue(1);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

        }
        public DbSet<User> User { get; set; }
        public DbSet<Barrio> Barrios { get; set; }
        public DbSet<UserLogin> Userlogin { get; set; }
        public DbSet<Cuidad> Cuidad { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<TamanioPaquete> TamanioPaquetes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

    }
}
