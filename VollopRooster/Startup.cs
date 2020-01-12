using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Interfaces;
using DAL.Memory;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VollopRooster.Repository;
using VollopRooster.Repository.Interfaces;

namespace VollopRooster
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //memory services
            //services.AddSingleton<IEmployeeContext, EmployeeMemory>();
            //services.AddSingleton<IEventContext, EventMemory>();
            //services.AddSingleton<IShiftContext, ShiftMemory>();
            //services.AddSingleton<IAvailabilityContext, AvailabilityMemory>();
            //services.AddSingleton<IScheduleContext, ScheduleMemory>();

            services.AddSingleton<IEmployeeLogic, EmployeeLogic>();
            services.AddSingleton<IEventLogic, EventLogic>();
            services.AddSingleton<IShiftLogic, ShiftLogic>();
            services.AddSingleton<IAvailabilityLogic, AvailabilityLogic>();
            services.AddSingleton<IScheduleLogic, ScheduleLogic>();

            services.AddSingleton<IEmployeeContext, EmployeeContext>();
            services.AddSingleton<IShiftContext, ShiftContext>();
            services.AddSingleton<IAvailabilityContext, AvailabilityContext>();
            services.AddSingleton<IScheduleContext, ScheduleContext>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
