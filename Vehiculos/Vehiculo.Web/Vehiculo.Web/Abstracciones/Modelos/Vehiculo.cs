using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class VehiculoBase
    {
        [Required(ErrorMessage = "El campo Placa es requerido")]
        [RegularExpression(@"[A-Za-z]{3}-[1-9]{3}", ErrorMessage = "El formato de la placa tiene que ser ###-123")]
        public string Placa {  get; set; }

        [Required(ErrorMessage = "El campo Color es requerido")]
        [StringLength(40, ErrorMessage ="Color tiene que tener minimo 4 letras y maximo 40", MinimumLength = 4)]
        public string Color { get; set; }

        [Required(ErrorMessage = "El campo Año es requerido")]
        [RegularExpression(@"(19|20)\d\d", ErrorMessage ="El formato del año es incorrecto")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El campo Precio es requerido")]
        public Decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido")]
        [EmailAddress]
        public string CorreoPropietario { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        [Phone]
        public string TelefonoPropietario { get; set; }
    }

    public class VehiculoRequest:VehiculoBase {
        public Guid IdModelo { get; set; }
      
     }

    public class VehiculoResponse : VehiculoBase
    {
        public Guid Id { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
    }

    public class VehiculoDetalle : VehiculoResponse { 
    
        public bool RevisionValida {  get; set; }
        public bool RegistroValido { get; set; }
    }
}
