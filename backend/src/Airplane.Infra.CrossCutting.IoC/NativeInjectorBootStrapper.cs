using Airplane.Application.Interfaces;
using Airplane.Application.Services;
using Airplane.Domain.Intefaces;
using Airplane.Infra.CrossCutting.WebRequest.Interfaces;
using Airplane.Infra.CrossCutting.WebRequest.Services;
using Airplane.Infra.Data.Context;
using Airplane.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Airplane.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<AirplaneContext>();

            
            services.AddScoped<IRequestService, RequestService>();

            services.AddScoped<IAircraftAppService, AircraftAppService>();

            services.AddScoped<IAircraftRepository, AircraftRepository>();

        }
    }
}
