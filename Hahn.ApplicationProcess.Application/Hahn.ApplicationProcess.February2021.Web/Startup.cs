using Hahn.ApplicationProcess.February2021.Data.Database;
using Hahn.ApplicationProcess.February2021.Data.Repository;
using Hahn.ApplicationProcess.February2021.Domain.Repository;
using Hahn.ApplicationProcess.February2021.Presentation.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System.Reflection;

namespace Hahn.ApplicationProcess.February2021.Web
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

            #region Swagger Dependencies

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application-Assets API", Version = "v1" });

                
            });

            #endregion

            services.AddDbContext<DatabaseContext>(options =>
                options.UseInMemoryDatabase(databaseName: "AssetDB"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            services.AddTransient<DatabaseContext>();

            services.AddScoped(typeof(IAssetRepository), typeof(AssetRepository));
            services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));
            services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));

            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Add MediatR
            services.AddMediatR(typeof(AssetHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DepartmentHandler).GetTypeInfo().Assembly); 
            services.AddMediatR(typeof(CountryHandler).GetTypeInfo().Assembly);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
              options.WithOrigins("http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
            });
        }
    }
}
