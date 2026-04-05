using Abstracciones.DA;
using Abstracciones.Flujo;
using Abstracciones.Modelos;
using Abstracciones.Reglas;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class AutenticacionReglas : IAutenticacionReglas
    {

        public IUsuarioDA _usuarioDA;
        public IConfiguration _configuration;

        public AutenticacionReglas(IUsuarioDA usuarioDA, IConfiguration configuration)
        {
            _usuarioDA = usuarioDA;
            _configuration = configuration;
        }

        public async Task<Token> LoginAsync(LoginResponse login)
        {
            Token respuestaToken = new Token() { AccessToken = string.Empty, ValidacionExitosa = false };
            var resultadoVerificacion = await VerificarLoginAsync(login);
            if (!resultadoVerificacion)
                return respuestaToken;
            TokenConfiguracion tokenConfiguracion = _configuration.GetSection("Token").Get<TokenConfiguracion>();
            JwtSecurityToken token = await GenerarToken(login, tokenConfiguracion);
            respuestaToken.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            respuestaToken.ValidacionExitosa = true;
            return respuestaToken;
        }

        private async Task<bool> VerificarLoginAsync(LoginResponse login)
        {
            var usuario = await _usuarioDA.ObtenerUsuario(new Usuario { NombreUsuario = login.NombreUsuario, CorreoElectronico = login.CorreoElectronico });
            return (login != null && login.PasswordHash == usuario.PasswordHash);
        }

        private async Task<JwtSecurityToken> GenerarToken(LoginResponse login, TokenConfiguracion tokenConfiguracion)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguracion.key));
            List<Claim> claims = await GenerarClaims(login);
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(tokenConfiguracion.Issuer, tokenConfiguracion.Audience, claims, expires: DateTime.Now.AddMinutes(tokenConfiguracion.Expires), signingCredentials: credentials);
            return token;
        }

        private async Task<List<Claim>> GenerarClaims(LoginResponse login)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, login.NombreUsuario));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, login.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, login.CorreoElectronico));
            var perfiles = await ObtenerPerfiles(login);

            foreach (var perfil in perfiles)
            {
                claims.Add(new Claim(ClaimTypes.Role, perfil.Id.ToString()));
            }
            return claims;
        }
        private async Task<IEnumerable<Perfil>> ObtenerPerfiles(LoginResponse login)
        {
            return await _usuarioDA.ObtenerPerfilesxUsuario(new Usuario { NombreUsuario = login.NombreUsuario, CorreoElectronico = login.CorreoElectronico });
        }

    }
}