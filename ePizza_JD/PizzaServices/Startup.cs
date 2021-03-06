using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ePizza_JD.Models;
using ePizza_JD.Models.Data;
using ePizza_JD.Models.Repositories;
using ePizza_JD.WebApp.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ePizza_JD.API
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


            services.AddAuthentication(svc =>
            {
                svc.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                svc.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Configuration.GetSection("Tokens:AuthenticationProviderKey").Value,
            options =>
            {
                options.RequireHttpsMetadata = false;
                //options.Audience = //Configuration.GetSection("Tokens:Audience").Value;
                //options.ClaimsIssuer = Configuration.GetSection("Tokens:Issuer").Value;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidAudience = Configuration["Tokens:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                };
                options.SaveToken = true;
            });
            
            //1. context
            //online server
            var connectionString = Configuration.GetConnectionString("DB");
            //local

            //var connectionString = Configuration.GetConnectionString("LocalDB");
            services.AddDbContext<PizzaServiceDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);


            //TODO cors terug aanleggen => testing met de apigateway

            //2b. Cors 
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
            //3. Repos
            services.AddScoped(typeof(IToppingRepo), typeof(ToppingRepo));
            services.AddScoped(typeof(IPizzaRepo), typeof(PizzaRepo));
            services.AddScoped(typeof(IReviewRepo), typeof(ReviewRepo));
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));


            //4. Mapper
            services.AddAutoMapper(typeof(ePizza_JDProfiles));


            //5. Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ePizza_JD", Version = "v1" });
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PizzaServiceDbContext context )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseSwagger(); //enable swagger
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger"; //path naar de UI: /swagger/index.html
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ePizza_JD");
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
