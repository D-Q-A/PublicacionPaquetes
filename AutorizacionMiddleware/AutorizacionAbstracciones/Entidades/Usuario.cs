using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorizacionAbstracciones.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; }
        public string PasswordHash { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Guid UsuarioCrea { get; set; }
        public Guid UsuarioModifica { get; set; }

    }
}
