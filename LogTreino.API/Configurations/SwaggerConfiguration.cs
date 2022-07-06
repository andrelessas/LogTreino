using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LogTreino.API.Configurations
{
    public class SwaggerConfiguration : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public SwaggerConfiguration(IApiVersionDescriptionProvider provider) => _provider = provider;
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var descricao in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(descricao.GroupName,CriarInformacoesAPI(descricao));
            }
        }

        private OpenApiInfo CriarInformacoesAPI(ApiVersionDescription descricao)
        {
            var info = new OpenApiInfo()
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
            };
            return info;
        }
    }
}