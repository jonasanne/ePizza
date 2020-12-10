using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CartServices.Data;
using CartServices.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using CartServices.Models;

namespace CartServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();




            //zonder dit error bij ophalen data
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //1. context

            //online server
            var connectionString = Configuration.GetConnectionString("DB");

            //local
            //var connectionString = Configuration.GetConnectionString("LocalDB");
            services.AddDbContext<CartServicesContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);



            //3. Repos
            services.AddScoped(typeof(ICartRepo), typeof(CartRepo));
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

            //Cors 
            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowOrigins", builder =>
                {
                    builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowAnyOrigin() // niet toegelaten indien credentials
                    .WithOrigins("https://localhost", "http://localhost:8080", "https://epizza.netlify.app")
                    .AllowCredentials();
                });
            });


            ////4. Mapper 
            services.AddAutoMapper(typeof(CartServicesProfiles));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "CartService v1.0", Version = "v1.0" });
                //c.IncludeXmlComments(xmlPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger(); //enable swagger
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger"; //path naar de UI: /swagger/index.html
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "CartService v1.0");
            });
            app.UseCors("MyAllowOrigins");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
