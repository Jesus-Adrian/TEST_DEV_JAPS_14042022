using System.ComponentModel.DataAnnotations;

namespace TokaDomain.DTO
{
    public class ModificarPersonaFisica : PersonaFisica
    {
        [Required]
        public int IdPersonaFisica { get; set; }
    }
}
