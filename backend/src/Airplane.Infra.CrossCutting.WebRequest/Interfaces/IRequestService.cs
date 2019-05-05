using Airplane.Infra.CrossCutting.WebRequest.Enum;
using System.Net.Http;

namespace Airplane.Infra.CrossCutting.WebRequest.Interfaces
{
    public interface IRequestService
    {
        TTipoRetorno Criar<TTipoRetorno>(HttpMethod metodo, string url, object objetoEnvio = null,
            TokenRequestType? tipoToken = null, string token = null, bool enviarObjetoComoJson = true);

    }
}
