using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ePizza_JD.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RestaurantServices.Data;
using RestaurantServices.Repositories;

namespace RestaurantServices
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

            //MongoDB-configuratie
            services.Configure<MongoSettings>(Configuration.GetSection(nameof(MongoSettings)));
            //MongoDB-registraties
            services.AddSingleton<IMongoSettings>(sp => sp.GetRequiredService<IOptions<MongoSettings>>().Value);


            //context en repo's
            services.AddSingleton<RestaurantServicesContext>();
            services.AddScoped(typeof(IRestaurantRepo), typeof(RestaurantRepo));
            services.AddScoped(typeof(IReviewRepo), typeof(ReviewRepo));

            services.AddScoped<Seeder>(); // geen singleton mogelijk

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


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RestaurantServicesContext context, Seeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            };

            app.UseHttpsRedirection();

            app.UseCors("MyAllowOrigins");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            seeder.initDatabase();
        }
    }
}
