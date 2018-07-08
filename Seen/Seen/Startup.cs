using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            services.AddScoped<Answers>();
        }

        public void ConfigureTestingServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<SeenContext>(opt => opt.UseInMemoryDatabase("testdatabase"));
            services.AddScoped<SightingRepository>();
            services.AddScoped<Answers>();
        }

        public void ConfigureHerokuServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<SeenContext>(options =>
            options.UseNpgsql(Configuration["ConnectionString2"]));
            services.AddScoped<SightingRepository>();
            services.AddScoped<Answers>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
