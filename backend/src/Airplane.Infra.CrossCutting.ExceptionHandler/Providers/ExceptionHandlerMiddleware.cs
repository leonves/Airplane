using System;
using Airplane.Domain.Entities;
using Airplane.Domain.Intefaces;
using Airplane.Infra.CrossCutting.ExceptionHandler.Extensions;
using Airplane.Infra.CrossCutting.ExceptionHandler.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Airplane.Infra.CrossCutting.ExceptionHandler.Providers
{
    public static class ExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = async context =>
                {
                    var _exceptionHandler = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (_exceptionHandler == null)
                        return;
                    
                    var _repositoryAircraft = context.RequestServices.GetService<IAircraftRepository>();

                    var _statusCode = _exceptionHandler.Error is ApiException
                                        ? ((ApiException)_exceptionHandler.Error).StatusCode
                                        : HttpStatusCode.InternalServerError;

                    context.Response.StatusCode = (int)_statusCode;

                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(new DetalhesExceptionViewModel
                    {
                        StatusCode = _statusCode,
                        Message = _exceptionHandler.Error.Message
                    }.ToString());
                }
            });
        }
    }
}
