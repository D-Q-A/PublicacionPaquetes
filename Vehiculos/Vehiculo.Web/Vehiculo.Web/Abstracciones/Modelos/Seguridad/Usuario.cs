using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Usuario
    {
       
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string? PasswordHash { get; set; } = "0";
        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

    }

    public class UsuarioResponse : Usuario
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmarPassword { get; set; }
    }
}
