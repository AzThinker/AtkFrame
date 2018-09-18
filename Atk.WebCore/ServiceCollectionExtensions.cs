using Atk.DataPortal;
using Atk.WebCore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atk.WebCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            //add accessor to HttpContext
            services.AddHttpContextAccessor();

            //create, initialize and configure the engine
            var engine = EngineContext.Create();
            engine.Initialize(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var serviceProvider = engine.ConfigureServices(services, configuration);


            return serviceProvider;
        }

        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
