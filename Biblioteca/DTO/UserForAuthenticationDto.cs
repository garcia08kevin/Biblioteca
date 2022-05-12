using Biblioteca.Models;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.DTO
{
    public class UserForAuthenticationDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Se requiere Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ser requiere contraseña.")]
        public string Password { get; set; }
    }
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
