using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LogTreino.CORE.ExcecoesPersonalisadas;
using LogTreino.CORE.Shared;
using Newtonsoft.Json;

namespace LogTreino.API.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly IConfiguration _configuration;

        public GlobalExceptionHandlerMiddleware(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {   
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // LogExcecao.GravaExcecaoTxt(exception, context);

            context.Response.ContentType = "application/json";

            var json = new ErrorResponse();

            if (exception is ExcecaoPersonalizada)
            {
                json.Status = 400;

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                json.Detalhes = exception.Message;
            }
            else
            {
                json.Status = 500;

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                json.Detalhes = exception.Message;
                // json.MensagemBruta = exception.Message;
            }
            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}