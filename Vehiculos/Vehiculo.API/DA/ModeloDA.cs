using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class ModeloDA : IModeloDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public ModeloDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<IEnumerable<ModeloResponse>> Obtener()
        {
            string query = @"ObtenerModelos";
            var resultado = await _sqlConnection.QueryAsync<ModeloResponse>(query);
            return resultado;
        }

        public async Task<IEnumerable<ModeloResponse>> Obtener(Guid Id)
        {
            string query = @"ObtenerModeloPorID";
            var resultado = await _sqlConnection.QueryAsync<ModeloResponse>(query, new { Id = Id });
            return resultado;
        }
    }
}
