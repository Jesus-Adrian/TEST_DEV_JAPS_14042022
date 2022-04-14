using TokaDomain.DTO;

namespace TokaService.Interfaces
{
    public interface IAutenticacionUsuarioService
    {
        public RespuestaGenerica AutenticarUsuario(string correo, string contrasena);
    }
}
