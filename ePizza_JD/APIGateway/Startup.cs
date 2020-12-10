using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGateway
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();


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
            app.UseCors("MyAllowOrigins");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    if (env.IsDevelopment())
                    {
                        await context.Response.WriteAsync(
                                $"<div>Hello World van (Docker en)  Ocelot gateway op {currentUrl} !</div>" +
                                "<ul>" +
                                "<li><a href='pizzas'>Lijst van pizza-API </a></li>" +
                                "<li><a href='toppings'>Lijst van topping-API </a></li>" +
                                "<li><a href='reviews'>lijst Review-API</a></li>" +
                                "<li><a href='restaurants'>lijst Restaurant-API</a></li>" +
                                   "</ul></br>" +
                                "<ul>" +
                                "<li><a href='http://localhost:32778/' target='_blank' rel='noopener noreferrer'/>AdminCorner op andere webserver.(IdentityServices)</a></li>" +
                                "</ul>")
                            ;
                    };
                });
            });

            app.UseWebSockets(); //vóór UseOcelot
            await app.UseOcelot();

        }
    }
}

