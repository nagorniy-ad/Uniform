using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Uniform.Core.Repositories;
using Uniform.Core.Services;
using Uniform.DataAccess.Context;
using Uniform.DataAccess.Repositories;
using Uniform.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Uniform.WebApi
{
    public class Startup
    {
        private readonly string _connectionString;

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            _connectionString = configuration.GetConnectionString("Uniform");
            if (_connectionString.Contains("%CONTENTROOTPATH%"))
            {
                _connectionString = _connectionString.Replace("%CONTENTROOTPATH%", env.ContentRootPath);
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UniformContext>(opt => opt.UseSqlServer(_connectionString));
            services.AddTransient<IFormRepository, FormRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IFormService, FormService>();
            services.AddCors();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
