using Dapper;
using AutorizacionAbstracciones.DA;
using AutorizacionAbstracciones.Modelos;
using System.Data.SqlClient;
using Helpers;



namespace Autorizacion.DA
{
    public class SeguridadDA : ISeguridadDA
    {
        IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public SeguridadDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<IEnumerable<Perfil>> ObtenerPerfilesxUsuario(Usuario usuario)
        {
            string sql = @"[ObtenerPerfilesxUsuario]";
            var resultado = await _sqlConnection.QueryAsync<AutorizacionAbstracciones.Entidades.Perfil>(sql, new { CorreoElectronico = usuario.CorreoElectronico, NombreUsuario = usuario.NombreUsuario });
            return Convertidor.ConvertirLista<AutorizacionAbstracciones.Entidades.Perfil, AutorizacionAbstracciones.Modelos.Perfil>(resultado) ;
        }

        public async Task<Usuario> ObtenerUsuario(Usuario usuario)
        {
            string sql = @"[ObtenerUsuario]";
            var resultado = await _sqlConnection.QueryAsync<AutorizacionAbstracciones.Entidades.Usuario>(sql, new { CorreoElectronico = usuario.CorreoElectronico, NombreUsuario = usuario.NombreUsuario });
            return Convertidor.Convertir<AutorizacionAbstracciones.Entidades.Usuario, AutorizacionAbstracciones.Modelos.Usuario>(resultado.FirstOrDefault());
        }
    }
}
