using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.API.Middleware;
using LogTreino.DATA.Context;
using LogTreino.DATA.Repository;
using LogTreino.DOMAIN.Interfaces;
using LogTreino.DOMAIN.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LogTreino.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<LogTreinoContext>();
            services.AddScoped<GlobalExceptionHandlerMiddleware>();
            // services.AddTransient<>();
            services.AddScoped<IAtletaService,AtletaService>();
            services.AddScoped<IAtletaRepository,AtletaRepository>();
            services.AddScoped<IMedidasRepository,MedidasRepository>();
            services.AddScoped<IMedidasService,MedidasService>();
            services.AddScoped<ITreinoDiaRepository,TreinoDiaRepository>();
            services.AddScoped<ITreinoDiaServices,TreinoDiaServices>();
            services.AddScoped<IAparelhoService,AparelhoService>();
            services.AddScoped<IAparelhoRepository,AparelhoRepository>(); 
        }
    }
}