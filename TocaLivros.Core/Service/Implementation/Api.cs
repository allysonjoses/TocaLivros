using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TocaLivros.Domain.Models;

namespace TocaLivros.Core.Service.Implementation
{
    public class Api : BaseApi, IApi
    {
        #region Login

        /// <summary>Obtém acesso na API via Auth basic</summary>
        /// <param name="usuario">usuario</param>
        /// <param name="password">password</param>
        /// <returns>
        /// <c>string</c> Token da autenticação
        /// </returns>
        public async Task<string> LoginAsync(string usuario, string password)
        {
            string Token = "";
            var grant = $"grant_type=password&username={usuario}&password={password}";

            var objectContent = new StringContent(grant, Encoding.UTF8, "application/x-www-form-urlencoded");

            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var response = await client.PostAsync("api/authentication", objectContent);

                    var resultJson = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TokenModel>(resultJson);

                    if (response.IsSuccessStatusCode)
                    {
                        //Insere o Token Gerado pela API
                        Token = result.AccessToken;
                    }
                    else throw new Exception(result.ErrorDescription);

                    //Retorno ao try catch
                    return response;
                }
            });

            return Token;
        }

        #endregion

        #region Usuario

        /// <summary>
        /// Retorna o usuário atualmente logado
        /// </summary>
        /// <returns>Objeto <c>Usuario</c></returns>
        public async Task<Usuario> GetUsuarioAsync()
        {
            Usuario result = null;

            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var response = await client.GetAsync("api/usuario");

                    if (response.IsSuccessStatusCode)
                    {
                        var resultJSON = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<Usuario>(resultJSON);
                    }

                    //Retorno ao try catch
                    return response;
                }
            });

            return result;
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <param name="usuario">Usuario a ser criado</param>
        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var json = JsonConvert.SerializeObject(usuario);
                    var objectContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/usuario", objectContent);

                    //Retorno ao try catch
                    return response;
                }
            });
        }

        #endregion

        #region Produto

        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        /// <returns>List <c>Produto</c></returns>
        public async Task<List<Produto>> GetProdutoAsync()
        {
            List<Produto> result = new List<Produto>();

            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var response = await client.GetAsync("api/produto");

                    if (response.IsSuccessStatusCode)
                    {
                        var resultJSON = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<Produto>>(resultJSON);
                    }

                    //Retorno ao try catch
                    return response;
                }
            });

            return result;
        }

        /// <summary>
        /// Retorna um produto específico
        /// </summary>
        /// <returns>Objeto <c>Produto</c></returns>
        public async Task<Produto> GetProdutoAsync(int id)
        {
            Produto result = null;

            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var response = await client.GetAsync($"api/produto/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        var resultJSON = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<Produto>(resultJSON);
                    }

                    //Retorno ao try catch
                    return response;
                }
            });

            return result;
        }

        /// <summary>
        /// Cria um novo Produto
        /// </summary>
        /// <param name="produto">Produto a ser criado</param>
        public async Task CreateProdutoAsync(Produto produto)
        {
            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var json = JsonConvert.SerializeObject(produto);
                    var objectContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/produto", objectContent);

                    //Retorno ao try catch
                    return response;
                }
            });
        }

        /// <summary>
        /// Atualiza um Produto
        /// </summary>
        /// <param name="produto">Produto a ser atualizado</param>
        public async Task UpdateProdutoAsync(Produto produto)
        {
            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var json = JsonConvert.SerializeObject(produto);
                    var objectContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync("api/produto", objectContent);

                    //Retorno ao try catch
                    return response;
                }
            });
        }

        #endregion

        #region Pedido

        /// <summary>
        /// Retorna todos os pedidos do usuário
        /// </summary>
        /// <returns>List <c>Pedido</c></returns>
        public async Task<List<Pedido>> GetPedidoAsync()
        {
            List<Pedido> result = new List<Pedido>();

            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var response = await client.GetAsync("api/pedido");

                    if (response.IsSuccessStatusCode)
                    {
                        var resultJSON = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<Pedido>>(resultJSON);
                    }

                    //Retorno ao try catch
                    return response;
                }
            });

            return result;
        }

        /// <summary>
        /// Retorna um pedido específico
        /// </summary>
        /// <returns>Objeto <c>Pedido</c></returns>
        public async Task<Pedido> GetPedidoAsync(int id)
        {
            Pedido result = null;

            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var response = await client.GetAsync($"api/pedido/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        var resultJSON = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<Pedido>(resultJSON);
                    }

                    //Retorno ao try catch
                    return response;
                }
            });

            return result;
        }

        /// <summary>
        /// Cria um novo Pedido
        /// </summary>
        /// <param name="pedido">Pedido a ser criado</param>
        public async Task CreatePedidoAsync(Pedido pedido)
        {
            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var json = JsonConvert.SerializeObject(pedido);
                    var objectContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/pedido", objectContent);

                    //Retorno ao try catch
                    return response;
                }
            });
        }

        /// <summary>
        /// Atualiza um Pedido
        /// </summary>
        /// <param name="pedido">Pedido a ser atualizado</param>
        public async Task UpdatePedidoAsync(Produto pedido)
        {
            await TryCatchAsync(async () =>
            {
                using (var client = BaseApi.HttpClient())
                {
                    var json = JsonConvert.SerializeObject(pedido);
                    var objectContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync("api/pedido", objectContent);

                    //Retorno ao try catch
                    return response;
                }
            });
        }

        #endregion
    }

    public class TokenModel
    {
        public override string ToString()
        {
            return AccessToken;
        }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }
    }
}
