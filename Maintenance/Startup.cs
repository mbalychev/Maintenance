using Maintenance.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintenance.Models.Employee;
using Maintenance.Controllers;
using Data.Entities;
using Maintenance.Repositories;
using Microsoft.AspNetCore.Http;
using Maintenance.Models;
using Maintenance.Services;

namespace Maintenance
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());
            services.AddDbContext<Context>();
            services.AddTransient<IServices<EngineerModel>, EngineerService>();
            services.AddTransient<IHardWaresService<HardWareModel>, HardWareService>();
            services.AddTransient<IServices<MonitorModel>, MonitorService>();
            services.AddTransient<IServices<FiscalRegistratorModel>, FiscalRegistratorService>();
            services.AddTransient<IServices<ComputerModel>, ComputerService>();
            services.AddTransient<IServices<MaintenancePlanModel>, MaintenancePlanService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
