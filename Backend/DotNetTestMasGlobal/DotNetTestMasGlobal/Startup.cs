using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using DotNetTestMasGlobal.Business;
using DotNetTestMasGlobal.Business.Interfaces;
using DotNetTestMasGlobal.Data.Interfaces;
using DotNetTestMasGlobal.Data;

namespace DotNetTestMasGlobal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            AddSwagger(services);
            services.AddCors();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository>(option =>
               new EmployeeRepository(Configuration.GetValue<string>("EmployeeEndpointURL"))
            );

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNetTestMasGlobal API V1");
            });

            app.UseCors(x => x
                .WithOrigins("http://localhost:4200/")
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()); 

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"DotNetTestMasGlobal {groupName}",
                    Version = groupName,
                    Description = "DotNetTestMasGlobal API",
                    Contact = new OpenApiContact
                    {
                        Name = "Julian Slonim Limited",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/jslonim/DotNetTestMasGlobal"),
                    }
                });
            });
        }
    }
}
