using System.Net.Http.Headers;
using TocaLivros.Core.Helpers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System;

namespace TocaLivros.Core.Service
{
    public class BaseApi
    {
        /// <summary>
        /// Retorna um client já configurado para uso
        /// </summary>
        public static HttpClient HttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Settings.AdressAPI),
                Timeout = TimeSpan.FromSeconds(20)
            };

            if (Settings.Token != string.Empty)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);

            return client;
        }

        /// <summary>
        /// Abstrai o try catch, evitando reuso de código
        /// </summary>
        /// <param name="method">Operações a serem realizadas</param>
        protected static async Task TryCatchAsync(Func<Task<HttpResponseMessage>> method)
        {
            try
            {
                using (var response = await method.Invoke())
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var resultError = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            throw new UnauthorizedAccessException("Você não possui permissão para acessar esse conteúdo. Logue-se novamente!");
                        }

                        throw new Exception
                            ($"Erro na solicitação \n{resultError}");
                    }
                }
            }
            catch (WebException ex)
            {
                throw new WebException($"Erro de Conexão \n{ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                throw new TaskCanceledException($"Tempo de solicitação excedido \n{ex.Message}");
            }
        }
    }
}
