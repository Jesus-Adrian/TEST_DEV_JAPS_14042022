using System;
using System.ComponentModel.DataAnnotations;

namespace TokaDomain.DTO
{
    public class PersonaFisica
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string ApellidoMaterno { get; set; }
        [Required]
        [MaxLength(13)]
        public string Rfc { get; set; }
        [Required]
        public int UsuarioAgrega { get; set; }
        [Required]
        public DateTime? FechaNacimiento { get; set; }
    }
}
