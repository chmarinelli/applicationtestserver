using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using TestServer.Api.Filters;
using TestServer.BL.Mappers;
using TestServer.BL.UnitOfWork;
using TestServer.DM.Context;

namespace TestServer.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.WithOrigins(Configuration["PathsConfig:PortalUrl"])
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });

            services.AddControllers(options => {
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UnitOfWork>());

            services.AddDbContext<TestServerContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("TestServer.Api"));
            });

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<TestServerMappingProfile>();
            });

            services.AddTransient<UnitOfWork>();
            services.Scan(scan =>
                scan.FromAssemblies(Assembly.Load("TestServer.BL"))
                    .AddClasses()
                    .AsMatchingInterface()
                    .WithTransientLifetime());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseWelcomePage();
        }
    }
}
