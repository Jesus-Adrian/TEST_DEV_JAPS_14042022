using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TokaDataAccess.Repository.Interfaces;
using TokaDomain.Modelos;
using TokaDomain.Respuesta;

namespace TokaDataAccess.Repository.Implementaciones
{
    public class PersonaFisicaRepositorio : IPersonaFisicaRepositorio
    {
        private readonly TokaDBContext _context;

        public PersonaFisicaRepositorio(TokaDBContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public RespuestaSP EliminarPersonaFisica(int idPersonaFisica)
        {
            return _context.RespuestaSP.FromSqlInterpolated($"sp_EliminarPersonaFisica {idPersonaFisica} ").AsEnumerable().FirstOrDefault();
        }

        public RespuestaSP ModificarPersonaFisica(TbPersonasFisicas modelo)
        {
            return _context.RespuestaSP.FromSqlInterpolated($"sp_ActualizarPersonaFisica {modelo.IdPersonaFisica}, { modelo.Nombre},{modelo.ApellidoPaterno},{modelo.ApellidoMaterno},{modelo.Rfc},{modelo.FechaNacimiento},{modelo.UsuarioAgrega}").AsEnumerable().FirstOrDefault();
        }

        public List<TbPersonasFisicas> ObtenerPersonasFisicas()
        {
            return _context.PersonasFisica.Where(x => x.Activo == true).ToList();
        }

        public TbPersonasFisicas ObtenerUsuario(string correo, string contrasena)
        {
            throw new NotImplementedException();
        }

        public RespuestaSP RegistrarPersonaFisica(TbPersonasFisicas modelo)
        {
            return _context.RespuestaSP.FromSqlInterpolated($"sp_AgregarPersonaFisica { modelo.Nombre},{modelo.ApellidoPaterno},{modelo.ApellidoMaterno},{modelo.Rfc},{modelo.FechaNacimiento},{modelo.UsuarioAgrega}").AsEnumerable().FirstOrDefault();
        }
    }
}
