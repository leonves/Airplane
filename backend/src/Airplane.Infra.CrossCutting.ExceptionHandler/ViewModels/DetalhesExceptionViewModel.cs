using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Serialization;

namespace Airplane.Infra.CrossCutting.ExceptionHandler.ViewModels
{
    internal class DetalhesExceptionViewModel
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
