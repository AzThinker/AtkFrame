using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atk.WebCore.Infrastructure
{
    public interface IAtkStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);


        void Configure(IApplicationBuilder application);


        int Order { get; }
    }
}
