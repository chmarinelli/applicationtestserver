using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestServer.DM.Context;
using TestServer.DM.SampleData;

namespace TestServer.DM
{
    public static class DbInitializer
    {
        public async static Task Init(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TestServerContext>();
            await context.Database.EnsureCreatedAsync();

            if (!context.PermitsTypes.Any())
            {
                await context.PermitsTypes.AddRangeAsync(PermitTypeSample.PermitsTypes);
                await context.SaveChangesAsync();
            }

            if (!context.Permits.Any())
            {
                await context.Permits.AddRangeAsync(PermitSample.Permits);
                await context.SaveChangesAsync();
            }
        }
    }
}
