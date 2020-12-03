using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace TestServer.Core.Extensions
{
    public static class WebHostExtensions
    {
        public static IHost Seed(this IHost webhost, Func<IServiceProvider, Task> seeder)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                seeder(scope.ServiceProvider).GetAwaiter().GetResult();
            }
            return webhost;
        }
    }
}
