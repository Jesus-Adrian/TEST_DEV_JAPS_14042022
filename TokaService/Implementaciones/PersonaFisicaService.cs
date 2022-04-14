using AutoMapper;
using System;
using System.Collections.Generic;
using TokaDataAccess.Repository.Interfaces;
using TokaDomain.DTO;
using TokaDomain.Modelos;
using TokaDomain.ViewModels;
using TokaService.Interfaces;

namespace TokaService.Implementaciones
{
    public class PersonaFisicaService : IPersonaFisicaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaFisicaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
            this._mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public RespuestaGenerica EliminarPersonaFisica(int idPersonaFisica)
        {
            var respuestaSP = _unitOfWork.PersonaFisicaRepositorio.EliminarPersonaFisica(idPersonaFisica);

            if (respuestaSP.Error != -50000 && respuestaSP.Error != -1)
            {
                return new RespuestaGenerica { Estatus = true, Mensaje = respuestaSP.MensajeError };
            }
            else
            {
                return new RespuestaGenerica { Estatus = false, Mensaje = respuestaSP.MensajeError };

            }
        }

        public RespuestaGenerica ModificarPersonaFisica(ModificarPersonaFisica modelo)
        {
            var personaFisica = _mapper.Map<ModificarPersonaFisica, TbPersonasFisicas>(modelo);

            var respuestaSP = _unitOfWork.PersonaFisicaRepositorio.ModificarPersonaFisica(personaFisica);

            if (respuestaSP.Error != -50000 && respuestaSP.Error != -1)
            {
                return new RespuestaGenerica { Estatus = true, Mensaje = respuestaSP.MensajeError };
            }
            else
            {
                return new RespuestaGenerica { Estatus = false, Mensaje = respuestaSP.MensajeError };

            }
        }

        public List<PersonaFisicaVM> ObtenerPersonasFisicas()
        {
            var personasFisicas = _unitOfWork.PersonaFisicaRepositorio.ObtenerPersonasFisicas();
            var personasFisicasVMs = _mapper.Map<List<TbPersonasFisicas>, List<PersonaFisicaVM>>(personasFisicas);
            return personasFisicasVMs;
        }

        public RespuestaGenerica RegistrarPersonaFisica(PersonaFisica modelo)
        {
            var personaFisica = _mapper.Map<PersonaFisica,TbPersonasFisicas>(modelo);
            var respuestaSP =_unitOfWork.PersonaFisicaRepositorio.RegistrarPersonaFisica(personaFisica);
            if (respuestaSP.Error!=-50000&&respuestaSP.Error!=-1)
            {
                return new RespuestaGenerica { Estatus = true, Mensaje = respuestaSP.MensajeError };
            }
            else
            {
                return new RespuestaGenerica { Estatus = false, Mensaje = respuestaSP.MensajeError };

            }
        }
    }
}
