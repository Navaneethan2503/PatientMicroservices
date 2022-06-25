using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PatientManagement.Domain.Aggregates.PatientAggregate;
using PatientManagement.Domain.Interfaces;
using PatientManagement.Infrastructure.Data.Contexts;
using PatientManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.API
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
            var connectionString = Configuration.GetConnectionString("DefaultConnectionString");
            services.AddControllers();
            services.AddDbContext<PatientManagementContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository<Patient>, Repository<Patient>>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Patient Management API",
                    Description = "Allows working with patient information in database",
                    TermsOfService = new Uri("http://www.cognizant.com"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Navaneethan.S",
                        Email = "S,Navaneethan@outlook.com",
                        Url = new Uri("https://github.com/nickilsekar2000")
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();   
                options.AllowAnyMethod();  
                options.AllowAnyHeader();  
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "Patient Management API"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
