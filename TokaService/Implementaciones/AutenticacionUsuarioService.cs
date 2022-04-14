using System;
using TokaDataAccess.Repository.Interfaces;
using TokaDomain.DTO;
using TokaService.Interfaces;

namespace TokaService.Implementaciones
{
    public class AutenticacionUsuarioService : IAutenticacionUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutenticacionUsuarioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public RespuestaGenerica AutenticarUsuario(string correo, string contrasena)
        {
            var respuestaSP = _unitOfWork.AutenticacionUsuarioRepositorio.AutenticarUsuario(correo, contrasena);
            if (respuestaSP.Error != -50000 && respuestaSP.Error != -1)
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
