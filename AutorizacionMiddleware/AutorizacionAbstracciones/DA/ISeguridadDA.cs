using AutorizacionAbstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorizacionAbstracciones.DA
{
    public interface ISeguridadDA
    {
        Task<Usuario> ObtenerUsuario(Usuario usuario);
        Task<IEnumerable<Perfil>> ObtenerPerfilesxUsuario(Usuario usuario);
    }
}
