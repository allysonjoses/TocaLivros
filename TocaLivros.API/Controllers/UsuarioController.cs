using TocaLivros.Domain.Contracts;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Web.Http;
using System.Net.Http;
using System.Linq;
using System.Net;
using System;

namespace TocaLivros.API.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioRepository _DataBase;

        public UsuarioController(IUsuarioRepository DataBase)
        {
            this._DataBase = DataBase;
        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<HttpResponseMessage> GetAsync()
        {
            var response = new HttpResponseMessage();

            try
            {
                var principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
                var identityClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                int UsuarioId = Convert.ToInt16(identityClaim.Value);

                var usuario = await _DataBase.GetAsync(UsuarioId);
                response = Request.CreateResponse(HttpStatusCode.OK, usuario);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> CreateAsync(Usuario usuario)
        {
            var response = new HttpResponseMessage();

            try
            {
                await _DataBase.CreateAsync(usuario.UserName);
                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            _DataBase.Dispose();
        }
    }
}
