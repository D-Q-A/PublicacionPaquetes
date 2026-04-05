using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.API
{
    public interface IUsuarioController
    {
        Task<IActionResult> PostAsync([FromBody]Usuario usuario);
        Task<IActionResult> ObtenerUsuario([FromBody] Usuario usuario);
    }
}
