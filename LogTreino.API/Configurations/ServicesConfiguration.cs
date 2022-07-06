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
                x.RegisterValidatorsFromAssemblyContaining<Aparelho_InsertValidations>();
                x.RegisterValidatorsFromAssemblyContaining<Aparelho_UpdateValidations>();
                x.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
            });
            
            service.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Log Treino",
                    Version = "1.0",
                    Description = "Essa Api serve para monitorar o treino do usuário.",
                    Contact = new OpenApiContact()
                        {
                            Name = "André Lessas", 
                            Email = "andrelessasp@gmail.com", 
                            Url = new Uri("https://github.com/andrelessas")
                        }
                });

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