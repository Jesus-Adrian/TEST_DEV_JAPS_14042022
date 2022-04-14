using TokaDomain.Respuesta;

namespace TokaDataAccess.Repository.Interfaces
{
    public interface IAutenticacionUsuarioRepositorio
    {
        public RespuestaSP AutenticarUsuario(string correo,string contrasena);
        public Usuario ObtenerUsuario(string correo,string contrasena);
    }
}
