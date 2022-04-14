using System.Collections.Generic;
using TokaDomain.DTO;
using TokaDomain.ViewModels;

namespace TokaService.Interfaces
{
    public interface IPersonaFisicaService
    {
        public List<PersonaFisicaVM> ObtenerPersonasFisicas();
        public RespuestaGenerica RegistrarPersonaFisica(PersonaFisica modelo);
        public RespuestaGenerica ModificarPersonaFisica(ModificarPersonaFisica modelo);
        public RespuestaGenerica EliminarPersonaFisica(int idPersonaFisica);
    }
}
