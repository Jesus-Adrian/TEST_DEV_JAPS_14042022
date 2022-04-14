using System.ComponentModel.DataAnnotations;

namespace TokaDomain.DTO
{
    public class LoginUsuario
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Contraseña { get; set; }
    }
}
