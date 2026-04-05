using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Seguridad
{
    public class Login
    {
        [Required]
        public string NombreUsuario { get; set; } = "0";
        [Required]
        public string PasswordHash { get; set; } = "0";
        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }
    }
    public class LoginResponse : Login
    {
        [Required]
        public Guid Id { get; set; }
    }

    public class LoginRequest : Login
    {
        [Required]
        public string Password { get; set; }
    }
}