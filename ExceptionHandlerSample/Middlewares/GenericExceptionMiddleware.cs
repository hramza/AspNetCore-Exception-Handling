using System;
using System.Text.Json;
using System.Threading.Tasks;
using ExceptionHandlerSample.Exeptions;
using ExceptionHandlerSample.Models;
using Microsoft.AspNetCore.Http;

namespace ExceptionHandlerSample.Middlewares
{
    public class GenericExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GenericExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                if (e is WeatherForecastException typedException)
                {
                    var response = FillResponse(typedException);

                    context.Response.StatusCode = response.ResponseCode;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response.ResponseMessage));
                }
                else
                {
                    throw e;
                }
            }
        }

        private ErrorMessage FillResponse(Exception ex) => new ErrorMessage { ResponseCode = StatusCodes.Status404NotFound, ResponseMessage = ex.Message };
    }
}
