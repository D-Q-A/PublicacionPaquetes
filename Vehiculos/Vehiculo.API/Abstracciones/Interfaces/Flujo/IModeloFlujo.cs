using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IModeloFlujo
    {
        Task<IEnumerable<ModeloResponse>> Obtener();
        Task<IEnumerable<ModeloResponse>> Obtener(Guid Id);
    }
}
