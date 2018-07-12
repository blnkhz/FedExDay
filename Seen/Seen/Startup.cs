using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seen.Entities;
using Seen.Models;
using Seen.Repository;

namespace Seen
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile($"appsettings.json", optional: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<SeenContext>(options =>
            options.UseNpgsql(Configuration["ConnectionString"]));
            services.AddScoped<SightingRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<Answers>();
        }

        public void ConfigureTestingServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<SeenContext>(opt => opt.UseInMemoryDatabase("testdatabase"));
            services.AddScoped<SightingRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<Answers>();
        }

        public void ConfigureHerokuServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<SeenContext>(options =>
            options.UseNpgsql(Configuration["ConnectionStringHeroku"]));
            services.AddScoped<SightingRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<Answers>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
