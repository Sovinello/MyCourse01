using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyCourse
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Ciò dimostra che questo framework è fortemente modulare;
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {      
            //Middeleware per intercettare eventuali errori
            //if (env.IsDevelopment())
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }

            //Middeleware per puntare direttamente ad un file statico tramite url
            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();    
            app.UseMvc(routeBuilder => {
                // courses/detail/5
                routeBuilder.MapRoute("default","{controller=Home}/{action=Index}/{id?}");
            });

            /*
            //Middleware per effettuare una response
            app.Run(async (context) =>
            {
                string nome = context.Request.Query["nome"];
                await context.Response.WriteAsync($"CIAO {nome.ToUpper()} !"); 
            });
            */
        }
    }
}