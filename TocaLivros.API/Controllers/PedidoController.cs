using TocaLivros.Domain.Contracts;
using TocaLivros.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Linq;
using System.Net;
using System;

namespace TocaLivros.API.Controllers
{
    [RoutePrefix("api/pedido")]
    public class PedidoController : ApiController
    {
        private readonly IPedidoRepository _DataBase;

        public PedidoController(IPedidoRepository DataBase)
        {
            this._DataBase = DataBase;
        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            var response = new HttpResponseMessage();

            try
            {
                var principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
                var identityClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                int UsuarioId = Convert.ToInt16(identityClaim.Value);
                response = Request.CreateResponse(HttpStatusCode.OK, await _DataBase.GetAllAsync(UsuarioId));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Authorize]
        [Route("{pedidoId}")]
        public async Task<HttpResponseMessage> GetAsync(int pedidoId)
        {
            var response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, await _DataBase.GetAsync(pedidoId));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> CreateAsync(Pedido pedido)
        {
            var response = new HttpResponseMessage();

            try
            {
                await _DataBase.CreateAsync(pedido);
                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        [HttpPut]
        [Route("")]
        public async Task<HttpResponseMessage> UpdateAsync(Pedido pedido)
        {
            var response = new HttpResponseMessage();

            try
            {
                await _DataBase.UpdateAsync(pedido);
                response = Request.CreateResponse(HttpStatusCode.OK);
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
