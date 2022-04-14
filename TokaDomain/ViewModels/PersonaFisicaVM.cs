using System;

namespace TokaDomain.ViewModels
{
    public class PersonaFisicaVM
    {
        public int IdPersonaFisica { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Rfc { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
