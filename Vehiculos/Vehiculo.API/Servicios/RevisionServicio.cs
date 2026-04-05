using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Revision;
using System.Net.Http;
using System.Text.Json;

namespace Servicios
{
    public class RevisionServicio: IRevisionServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public RevisionServicio(IHttpClientFactory httpClient, IConfiguracion configuracion)
        {
            _httpClient = httpClient;
            _configuracion = configuracion;

        }

        public async Task<Revision> Obtener(string placa)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsRevision", 
                "ObtenerRevision");
            var serviciosRegistro = _httpClient.CreateClient("ServicioRevision");
            var respuesta = await serviciosRegistro.GetAsync(string.Format
                (endPoint, placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultadoDeserializado = JsonSerializer.Deserialize<List<Revision>>(resultado, opciones);
            return resultadoDeserializado.FirstOrDefault();
        }
    }
}
