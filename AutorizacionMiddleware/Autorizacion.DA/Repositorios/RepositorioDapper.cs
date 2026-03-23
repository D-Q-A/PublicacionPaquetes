using AutorizacionAbstracciones.DA;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Autorizacion.DA.Repositorios
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuration;
        private SqlConnection _connection;

        public RepositorioDapper(IConfiguration configutarion)
        {
            _configuration = configutarion;
            _connection = new SqlConnection(_configuration.GetConnectionString("BDSeguridad"));
        }

        public SqlConnection ObtenerRepositorioDapper()
        {
            return _connection;
        }
    }
}
