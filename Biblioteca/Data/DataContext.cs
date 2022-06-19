using Biblioteca.Configuration;
using Biblioteca.DTO;
using Biblioteca.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Data
{
    public class DataContext : IdentityDbContext<UserLogin,IdentityRole<int>,int>
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
            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<UserLogin>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<UserLogin>()
            .Property(b => b.VehiculoId)
            .HasDefaultValue(1);
            modelBuilder.Entity<UserLogin>()
            .Property(b => b.CiudadId)
            .HasDefaultValue(1);
            modelBuilder.Entity<Paquete>()
            .Property(b => b.EstadoPaqueteId)
            .HasDefaultValue(1);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public void Configure(EntityTypeBuilder<RoleConfiguration> builder)
        {
            builder.HasData(
                new IdentityRole<int>
                {
                    Name = "Viewer",
                    NormalizedName = "VIEWER"
                },
                new IdentityRole<int>
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );
        }
        public DbSet<UserLogin> Userlogin { get; set; }
        public DbSet<Cuidad> Cuidad { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<TamanioPaquete> TamanioPaquetes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<EstadoPaquete> EstadoPaquetes { get; set; }

    }
}
