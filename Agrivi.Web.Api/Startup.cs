using Agrivi.Web.DataAccess;
using Agrivi.Web.DataAccess.Implementations;
using Agrivi.Web.DataAccess.Interfaces;
using Agrivi.Web.Services.Implementations;
using Agrivi.Web.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.IO;

namespace Agrivi.Web.Api
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
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Agrivi Assignment API", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "AgriviApi.xml");
                c.IncludeXmlComments(filePath);
            });

            //Repos DI
            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<ICarModelRepository, CarModelRepository>();

            //Services DI
            services.AddTransient<ICarManufacturerService, CarManufacturerService>();
            services.AddTransient<ICarModelService, CarModelService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var result = JsonConvert.SerializeObject(new { error = exception.Message });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Swagger
            app.UseSwagger(); 
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Agrivi API");
            });

            app.UseCors("CorsPolicy");

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
