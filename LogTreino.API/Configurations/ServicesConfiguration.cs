using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using LogTreino.DOMAIN.Validations;
using Microsoft.OpenApi.Models;

namespace LogTreino.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddServicesConfigutation(this IServiceCollection service)
        {
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()
                .Where(p => !p.IsDynamic));

            service.AddFluentValidation(x => 
            {
                x.RegisterValidatorsFromAssemblyContaining<AtletaValidations>();
                x.RegisterValidatorsFromAssemblyContaining<MedidasValidations>();
                x.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
            });
            
            service.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Log Treino", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);
                x.IncludeXmlComments(xmlPath);
            });

            service.AddMvc().AddJsonOptions(o => 
            {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        }
    }
}