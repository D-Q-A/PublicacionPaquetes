using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Numerics;

namespace DA
{
    public class VehiculoDA : IVehiculoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructores
        public VehiculoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            string query = @"AgregarVehiculo";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new {
               
                Id= Guid.NewGuid(),
                IdModelo= vehiculo.IdModelo,
                Placa= vehiculo.Placa,
                Color= vehiculo.Color,
                Anio= vehiculo.Anio,
                Precio= vehiculo.Precio,
                CorreoPropietario= vehiculo.CorreoPropietario,
                TelefonoPropietario= vehiculo.TelefonoPropietario
            });
            return resultado;
        }

        public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
        {
            await verificarVehiculo(Id);
            string query = @"EditarVehiculo";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id,
                IdModelo = vehiculo.IdModelo,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                Anio = vehiculo.Anio,
                Precio = vehiculo.Precio,
                CorreoPropietario = vehiculo.CorreoPropietario,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });
            return resultado;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await verificarVehiculo(Id);
            string query = @"EliminarVehiculo";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Id = Id
            });
            return resultado;
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultado = await _sqlConnection.QueryAsync<VehiculoResponse>(query);
            return resultado;
        }


        public async Task<VehiculoDetalle> Obtener(Guid Id)
        {
            string query = @"ObtenerVehiculoPorID";
            var resultado = await _sqlConnection.QueryAsync<VehiculoDetalle>(query, //Actualmente no disponible, preguntar a Experto en Base de Datos
                new {Id = Id});
            return resultado.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task verificarVehiculo(Guid Id)
        {
            VehiculoResponse? resultadoVehiculo = await Obtener(Id);
            if (resultadoVehiculo == null)
            { throw new Exception("No se encontró el vehículo"); }
        }

        #endregion
    }
}
