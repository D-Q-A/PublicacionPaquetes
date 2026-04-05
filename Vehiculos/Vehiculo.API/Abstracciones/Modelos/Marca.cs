using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Marca
    {
        public string Nombre { get; set; }

    }

    public class MarcaResponse : Marca
    {
        public Guid Id { get; set; }

    }
}
