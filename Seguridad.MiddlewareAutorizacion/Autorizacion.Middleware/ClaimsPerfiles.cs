using Autorizacion.Abstracciones.Flujo;
using Autorizacion.Abstracciones.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Autorizacion.Middleware
{
    public class ClaimsPerfiles
    {

        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private IAutorizacionFlujo _autorizacionFlujo;

        public ClaimsPerfiles(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext, IAutorizacionFlujo autorizacionFlujo)
        { 
        _autorizacionFlujo = autorizacionFlujo;
            ClaimsIdentity appIdentity = await verificarAutorizacion(httpContext);
            httpContext.User.AddIdentity(appIdentity);
            await _next(httpContext);
        }

        private async Task<ClaimsIdentity> verificarAutorizacion(HttpContext httpContext)
        {
           var claims=new List<Claim>();
            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                await ObtenerUsuario(httpContext, claims);
                await ObtenerPerfiles(httpContext, claims);
            }
            var appIdentity=new ClaimsIdentity(claims);
            return appIdentity;
        }

        private async Task ObtenerUsuario(HttpContext httpContext, List<Claim> claims)
        {
            var usuario = await ObtenerInformacionUsuario(httpContext);
            if (usuario is not null && !string.IsNullOrEmpty(usuario.Id.ToString()) && !string.IsNullOrEmpty(usuario.NombreUsuario.ToString()) && !string.IsNullOrEmpty(usuario.CorreoElectronico.ToString())) ;
            {
                claims.Add(new Claim(ClaimTypes.Email, usuario.CorreoElectronico));
                claims.Add(new Claim(ClaimTypes.Name, usuario.NombreUsuario));
                claims.Add(new Claim("IdUsuario", usuario.Id.ToString()));
            }
        }

        private async Task<Usuario> ObtenerInformacionUsuario(HttpContext httpContext)
        {
            return await _autorizacionFlujo.ObtenerUsuario(new Abstracciones.Modelos.Usuario { NombreUsuario = httpContext.User.Claims.Where(c => c.Type == "usuario").FirstOrDefault().Value });
        }
        private async Task ObtenerPerfiles(HttpContext httpContext, List<Claim> claims)
        {
            var perfiles = await obtenerInformacionPerfiles(httpContext);
            if (perfiles != null && perfiles.Any()) { 
            foreach (var perfil in perfiles) {
                    claims.Add(new Claim(ClaimTypes.Role, perfil.Id.ToString()));
                }
            }
        }

        private async Task<IEnumerable<Perfil>> obtenerInformacionPerfiles(HttpContext httpContext)
        {
            return await _autorizacionFlujo.ObtenerPerfilesxUsuario(new Abstracciones.Modelos.Usuario { NombreUsuario = httpContext.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value });
        }

    }
    public static class ClaimsUsuarioMiddlewareExtensions
    {
        public static IApplicationBuilder AutorizacionClaims(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClaimsPerfiles>();
        }
    }
}
