using System;
using System.Collections.Generic;
using System.Text;
using TokaDomain.Modelos;
using TokaDomain.Respuesta;

namespace TokaDataAccess.Repository.Interfaces
{
    public interface IPersonaFisicaRepositorio
    {
        public List<TbPersonasFisicas> ObtenerPersonasFisicas();
        public RespuestaSP RegistrarPersonaFisica(TbPersonasFisicas modelo);
        public RespuestaSP ModificarPersonaFisica(TbPersonasFisicas modelo);
        public RespuestaSP EliminarPersonaFisica(int idPersonaFisica);
        public TbPersonasFisicas ObtenerUsuario(string correo,string contrasena);
    }
}
