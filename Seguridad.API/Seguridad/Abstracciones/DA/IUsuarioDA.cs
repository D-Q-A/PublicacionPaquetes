using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.DA
{
    public interface IUsuarioDA
    {
        Task<Usuario> ObtenerUsuario(Usuario usuario);
        Task<Guid> AgregarUsuario(Usuario usuario);
        Task<IEnumerable<Perfil>> ObtenerPerfilesxUsuario(Usuario usuario);
        Task<Guid> EliminarUsuario(Guid Id);
    }
}
