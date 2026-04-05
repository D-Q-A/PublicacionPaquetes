using Abstracciones.Reglas;
using Abstracciones.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Abstracciones.DA;
using Microsoft.Extensions.Configuration;

namespace Flujo
{
    public class AutenticacionFlujo : IAutenticacionFlujo
    {

        private IAutenticacionReglas _autenticacionReglas;

        public AutenticacionFlujo(IAutenticacionReglas autenticacionReglas)
        {
            _autenticacionReglas = autenticacionReglas;
        }

        public async Task<Token> LoginAsync(LoginResponse login)
        {
            return await _autenticacionReglas.LoginAsync(login);
        }
    }
}
