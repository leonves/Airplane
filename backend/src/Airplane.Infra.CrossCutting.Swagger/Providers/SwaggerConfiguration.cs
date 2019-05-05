using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;

namespace Airplane.Infra.CrossCutting.Swagger.Providers
{
    /// <summary>
    /// Referências: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
    /// </summary>
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {

                //options.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\api-docs.xml");

                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Airplane Back-end",
                        Version = "v1",
                        Description = "API REST desenvolvida com ASP .NET Core 2.2 para a aplicação Airplane",
                        Contact = new Contact
                        {
                            Name = "Leonardo Araujo",
                            Url = "http://github.com/leonves",
                            Email = "leonevesaraujo@gmail.com"
                        }
                    });


                // Set the comments path for the Swagger JSON and UI.
                var _xmlPath = Path.Combine(AppContext.BaseDirectory, "api-docs.xml");

                options.IncludeXmlComments(_xmlPath);
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger()
                        .UseSwaggerUI(c =>
                        {
                            /* Rota para acessar a documentação */
                            c.RoutePrefix = "help";

                            /* Não alterar: Configuração aplicável tanto para servidor quanto para localhost */
                            c.SwaggerEndpoint("../swagger/v1/swagger.json", "Documentação API v1");
                        });
        }
    }
}
