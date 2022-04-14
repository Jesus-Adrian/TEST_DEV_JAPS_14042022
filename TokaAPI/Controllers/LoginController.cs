using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TokaDomain.DTO;
using TokaService.Interfaces;
using TokaService.JWT.Interfaces;

namespace TokaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IAutenticacionUsuarioService _autenticacionUsuarioService;
        private readonly IAutenticacionJWTService _autenticacionJWTService;

        public LoginController(IAutenticacionUsuarioService autenticacionUsuarioService, IAutenticacionJWTService autenticacionJWTService)
        {
            this._autenticacionUsuarioService = autenticacionUsuarioService ?? throw new ArgumentException(nameof(autenticacionUsuarioService));
            this._autenticacionJWTService = autenticacionJWTService ?? throw new ArgumentException(nameof(autenticacionJWTService));
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginUsuario loginUsuario)
        {
            try
            {
                var respuesta = _autenticacionUsuarioService.AutenticarUsuario(loginUsuario.Correo, loginUsuario.Contraseña);
                if (!respuesta.Estatus)
                {
                    return Unauthorized(respuesta.Mensaje);
                }
                var usuario = _autenticacionJWTService.AutenticarUsuario(loginUsuario.Correo, loginUsuario.Contraseña);
                var infousuario = _autenticacionJWTService.GenerarTokenJWT(usuario);
                return Ok(infousuario);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
        }
    }
}
