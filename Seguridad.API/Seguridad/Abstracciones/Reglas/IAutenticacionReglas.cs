using Abstracciones.Modelos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Reglas
{
    public interface IAutenticacionReglas
    {
        Task<Token> LoginAsync(LoginResponse login);
    }
}
