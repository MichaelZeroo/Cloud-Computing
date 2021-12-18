using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hub01.Models.DB;


namespace Hub01
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

            //CORS Security Notes
            // https://docs.microsoft.com/en-us/aspnet/core/signalr/security?view=aspnetcore-2.1
            // Shows UseCors with a list of ways of managing origins. 
            //Note that .AllowAnyOrigin() is a possible option but use carefully
            //e.g. with strong access keys, oauth2, or username/password for human-use clients
            //We need this when our clients are not web pages - eg phone apps, desktop apps
            app.UseCors(builder =>
               builder.AllowAnyOrigin().AllowAnyHeader()
               .WithMethods("GET", "POST").AllowCredentials());

            // 20180822 JPC this more recommended code is currently not working
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
