using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LogTreino.CORE.ExcecoesPersonalisadas;
using LogTreino.CORE.Shared;
using Newtonsoft.Json;
using NLog.Web;

namespace LogTreino.API.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
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
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            context.Response.ContentType = "application/json";

            var json = new ErrorResponse();

            if (exception is ExcecoesPersonalizadas)
            {
                json.Status = 400;

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;                

                json.Detalhes = exception.Message;
            }
            else
            {
                json.Status = 500;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                json.Detalhes = @"Ocorreu um erro inesperado. Para mais detalhes, consulte o log de erro.";
            }

            StackTrace st = new StackTrace(exception, true);
            //Get the first stack frame
            StackFrame frame = st.GetFrame(0);

            //Get the file name
            string fileName = frame.GetFileName();

            //Get the method name
            string methodName =  st.GetFrame(0).GetMethod().ReflectedType.ToString();
            //methodName = methodName.Substring(methodName.IndexOf('<'), methodName.LastIndexOf('>') - methodName.IndexOf('<'));

            //Get the line number from the stack frame
            int line = frame.GetFileLineNumber();

            //Get the column number
            int col = frame.GetFileColumnNumber();

            logger.Error(@$"\n Tipo= {exception.GetType()};
                            \n Message= {exception.Message};
                            \n Origem= {exception.Source};
                            \n FileName= {fileName};
                            \n Método= {methodName};
                            \n Linha= {line};
                            \n =====================================================================");

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}