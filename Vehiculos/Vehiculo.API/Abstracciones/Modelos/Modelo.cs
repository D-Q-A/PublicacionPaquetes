using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Modelo
    {
        public string Nombre { get; set; }
       
    }
    public class ModeloRequest : Modelo
    {
        public Guid IdMarca { get; set; }

    }

    public class ModeloResponse : Modelo
    {
        public Guid Id { get; set; }

    }
}
