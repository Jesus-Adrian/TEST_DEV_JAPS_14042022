using AutoMapper;
using TokaDomain.DTO;
using TokaDomain.Modelos;
using TokaDomain.Respuesta;
using TokaDomain.ViewModels;

namespace TokaDomain.AutoMapper
{
    public class PersonaFisicaMap : Profile
    {
        public PersonaFisicaMap()
        {
            CreateMap<TbPersonasFisicas, PersonaFisicaVM>();
            CreateMap<PersonaFisica, TbPersonasFisicas>();
            CreateMap<ModificarPersonaFisica, TbPersonasFisicas>();
              
        }
    }
}
