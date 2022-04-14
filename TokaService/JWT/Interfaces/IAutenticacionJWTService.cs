using TokaDomain.Respuesta;
using TokaDomain.ViewModels;

namespace TokaService.JWT.Interfaces
{
    public interface IAutenticacionJWTService
    {
        public Usuario AutenticarUsuario(string correo, string contrasena);
        public InfoUsuario GenerarTokenJWT(Usuario modelo);
    }
}
