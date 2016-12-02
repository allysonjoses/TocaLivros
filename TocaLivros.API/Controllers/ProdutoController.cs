using TocaLivros.Domain.Contracts;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System;

namespace TocaLivros.API.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoRepository _DataBase;

        public ProdutoController(IProdutoRepository DataBase)
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
                response = Request.CreateResponse(HttpStatusCode.OK, await _DataBase.GetAllAsync());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Authorize]
        [Route("{produtoId}")]
        public async Task<HttpResponseMessage> GetAsync(int produtoId)
        {
            var response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, await _DataBase.GetAsync(produtoId));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> CreateAsync(Produto produto)
        {
            var response = new HttpResponseMessage();

            try
            {
                await _DataBase.CreateAsync(produto);
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
        public async Task<HttpResponseMessage> UpdateAsync(Produto produto)
        {
            var response = new HttpResponseMessage();

            try
            {
                await _DataBase.UpdateAsync(produto);
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
