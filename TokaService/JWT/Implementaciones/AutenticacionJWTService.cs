using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokaDataAccess.Repository.Interfaces;
using TokaDomain.Respuesta;
using TokaDomain.ViewModels;
using TokaService.JWT.Interfaces;

namespace TokaService.JWT.Implementaciones
{
    public class AutenticacionJWTService : IAutenticacionJWTService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AutenticacionJWTService(IConfiguration configuration,IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }
        public Usuario AutenticarUsuario(string correo, string contrasena)
        {
            return _unitOfWork.AutenticacionUsuarioRepositorio.ObtenerUsuario(correo,contrasena);
        }

        public InfoUsuario GenerarTokenJWT(Usuario modelo)
        {
           
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, modelo.IdUsuario.ToString()),
                new Claim("nombre", modelo.Nombre),
                new Claim("apellidos", modelo.ApellidoPaterno+modelo.ApellidoMaterno),
                new Claim(JwtRegisteredClaimNames.Email, modelo.Correo),
                new Claim(ClaimTypes.Role, "usuario")
            };

            
            var _Payload = new JwtPayload(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );
            var token = new JwtSecurityTokenHandler().WriteToken(_Token);

            return new InfoUsuario { Token = token, IdUsuario = modelo.IdUsuario };
            
        }
    }
}
