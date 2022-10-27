using Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Runtime.CompilerServices;

namespace CompanyEmployeesWebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        //we’ve created an extension method in which we’ve registered the UseExceptionHandler middleware
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger) 
        {
            app.UseExceptionHandler(AppError =>
            {
                AppError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null) 
                    {
                        logger.LogError($"Somethings went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
