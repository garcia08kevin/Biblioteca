using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{
    public class UserLogin : IdentityUser<int>
    {
        //public DbSet<IdentityUserClaim<int>> IdentityUserClaim { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CiudadId { get; set; }
        public Cuidad? Cuidad { get; set; }
        public int? VehiculoId { get; set; }
        public Vehiculo? Vehiculo { get; set; }

    }
}
