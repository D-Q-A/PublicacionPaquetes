using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Reglas
{
    public interface IReglasRegistro
    {

        Task<bool> VehiculoEstaRegistrado(string placa, string email);
    }
}
