using System;
using System.Net;

namespace Airplane.Infra.CrossCutting.ExceptionHandler.Extensions
{
    /// <summary>
    /// ApiException customizada para a aplicação, podendo guardar o tipo da exception através do recurso System.Net.HttpStatusCode.
    /// <para>Através dessa exception, o retorno da API será com o status em questão.</para>
    /// </summary>
    public class ApiException : Exception
    {
        public ApiException()
        { }

        public ApiException(string message,
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
                Exception innerException = null
                )
            : base(message, innerException)
        {
            StatusCode = statusCode;

        }

        public ApiException(string message)
            : base(message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public ApiException(string message, Exception innerException)
            : base(message, innerException) { }

        public HttpStatusCode StatusCode { get; set; }
    }
}
