using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway
{
    public class Startup
    {
        private readonly IConfiguration cofiguration;

        public Startup(IConfiguration cofiguration)
        {
            this.cofiguration = cofiguration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();

            //TODO Security


            //Cors noodzakelijk voor front website
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("MyAllowOrigins", builder =>
            //    {
            //        builder.AllowAnyMethod()
            //       .AllowAnyHeader()
            //       //.AllowAnyOrigin()
            //       .WithOrigins("http://localhost:29507", "http://localhost:32809", "http://localhost:10568", "http://localhost:80") //naar appSettings�
            //       .AllowCredentials(); //.MUST!
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var currentUrl = "";
            app.Use((context, next) =>
            {
                currentUrl = context.Request.GetDisplayUrl();
                return next.Invoke();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseWebSockets(); //v��r UseOcelot
            await app.UseOcelot();

        }
    }
}
