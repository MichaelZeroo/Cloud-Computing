using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MVCManukauTech
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSignalR();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Required for use of files without C# programming eg js, css, html
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            //CORS Security
            // https://docs.microsoft.com/en-us/aspnet/core/signalr/security?view=aspnetcore-2.1
            // Shows UseCors with a list of origins. Note that .AllowAnyOrigin() is a possible option but use carefully
            app.UseCors(builder =>
               builder.AllowAnyOrigin().AllowAnyHeader()
               .WithMethods("GET", "POST").AllowCredentials());

            //app.UseCors(builder =>
            //   builder.WithOrigins("https://localhost:44353/", "https://manukau.ac.nz")
            //   .AllowAnyHeader().WithMethods("GET", "POST").AllowCredentials());

            //SignalR
            app.UseSignalR(routes =>
            {
                routes.MapHub<ServiceHub>("/servicehub");
            });
        }
    }
}
