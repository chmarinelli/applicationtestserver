using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TestServer.Core.Extensions;
using TestServer.DM;

namespace TestServer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Seed(DbInitializer.Init).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
