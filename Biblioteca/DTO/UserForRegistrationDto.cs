using Biblioteca.Models;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.DTO
{
    public class UserForRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Se requiere un Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Se requiere una contraseña")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}
