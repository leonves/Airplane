using Airplane.Infra.CrossCutting.WebRequest.Interfaces;
using Airplane.Infra.CrossCutting.WebRequest.Enum;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Airplane.Infra.CrossCutting.WebRequest.Services
{
    public class RequestService : IRequestService
    {
        public TTipoRetorno Criar<TTipoRetorno>(HttpMethod metodo, string url, object objetoEnvio = null, TokenRequestType? tipoToken = null, string token = null, bool enviarObjetoComoJson = true)
        {
            try
            {
                var _response = string.Empty;
                byte[] _dados;

                if (enviarObjetoComoJson)
                    _dados = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(objetoEnvio));
                
                else if (!enviarObjetoComoJson && objetoEnvio is string)
                    _dados = Encoding.UTF8.GetBytes(objetoEnvio as string);

                else
                    throw new Exception($"Não é possível converter para bytes um objeto do tipo {objetoEnvio.GetType()?.Name} para string.");

                using (var request = new WebClient())
                {
                    request.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    request.Headers.Add(HttpRequestHeader.CacheControl, "no-cache");

                   

                    var _url = new Uri(url);

                    switch (metodo)
                    {
                        case HttpMethod m when m == HttpMethod.Post:
                            _response = Encoding.UTF8.GetString(
                                request.UploadData(_url, HttpMethod.Post.Method, _dados));
                            break;

                        case HttpMethod m when m == HttpMethod.Get:
                            _response = request.DownloadString(_url);
                            break;

                        default:
                            throw new Exception("Método não permitido.");
                    }

                    return JsonConvert.DeserializeObject<TTipoRetorno>(_response);
                }
            }
            catch (Exception ex)
            {
                //TODO SalvarLog
                throw;
            }
        }
    }
}
