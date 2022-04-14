using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TokaDataAccess.Repository.Interfaces;
using TokaDomain.Respuesta;

namespace TokaDataAccess.Repository.Implementaciones
{
    public class AutenticacionUsuarioRepositorio : IAutenticacionUsuarioRepositorio
    {
        private readonly TokaDBContext _context;

        public AutenticacionUsuarioRepositorio(TokaDBContext context)
        {
            this._context = context ?? throw new ArgumentException(nameof(context));
        }
        public RespuestaSP AutenticarUsuario(string correo, string contrasena)
        {
            return _context.RespuestaSP.FromSqlInterpolated($"sp_AutenticarUsuario {correo},{contrasena} ").AsEnumerable().FirstOrDefault();

        }
        public Usuario ObtenerUsuario(string correo, string contrasena)
        {
            return _context.Usuario.FromSqlInterpolated($"sp_ObtenerUsuario {correo},{contrasena} ").AsEnumerable().FirstOrDefault();

        }
    }
}
