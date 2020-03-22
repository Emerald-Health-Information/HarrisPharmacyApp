#region copyright

/*

Harrison1 COSC 470 2019

File = Startup.cs

Author = Auto Generated

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam		2019-11-19			Added Headers

*/

#endregion copyright

using HarrisPharmacy.App.Areas.Identity;
using HarrisPharmacy.Data;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HarrisPharmacy.App
{
    /// <summary>
    /// Startup class for the application
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AuthContextConnection")), (ServiceLifetime.Transient));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<AuthDbContext>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbConnectionString")), (ServiceLifetime.Transient));

            services.AddMvc();
            services.AddControllersWithViews();

            services.AddFido(options =>
            {
                options.Licensee = "DEMO";
                options.LicenseKey = "eyJTb2xkRm9yIjowLjAsIktleVByZXNldCI6NiwiU2F2ZUtleSI6ZmFsc2UsIkxlZ2FjeUtleSI6ZmFsc2UsIlJlbmV3YWxTZW50VGltZSI6IjAwMDEtMDEtMDFUMDA6MDA6MDAiLCJhdXRoIjoiREVNTyIsImV4cCI6IjIwMjAtMDMtMjdUMDA6MDA6MDcuNTA3ODU3NiswMDowMCIsImlhdCI6IjIwMjAtMDItMjZUMDA6MDA6MDciLCJvcmciOiJERU1PIiwiYXVkIjo2fQ==.DYYbs0BypJJTdtkjXDGqtLRBI2L5nC8g4vzBh9zeW/mZNkqyPJpF1JxDr+qz4HyIxD1WGlQZXlU1n6hskN4vA2ozIS25MCMHSPTADX1e92iecUOFWgeTbqx/ai5VDykjv2TQ7TefF0Y1OGo5POgMeghkeOGZHXoaTO5XTsZyDt6QqebVCB1QkPjjKhgWEzg+M0XEM1RB57nC8CjE6xP+i6PVE0GQDyZUzykAmzgtF7E/LhWvSus2ATpne0bTqg+9Ltyla4u10sG5KDjkukm/0Qenqix4y3rVLts8CaWuN2sceeWUxZNx7HoWP8lM/XWsBMvof5g/aKiL7LIUxhEctHJaSc4QmT90hSGgeEDvkdbh5uwbL9NhCxv6z56Dt3sK5OlMerULM3+o4/l/Jt8zu6RBy4oeAiMyrAUFAXuCdjG6DerFNbOdF6zKIhBoYrdaSx871SFFTZ9YBDHRoBGwptbWwo1jsRXY9DpIu+t1mP+1HleZycUO32R4XuVDy4ccfOYpv9lMF/lMwN9LM1bol85uCZEN6u25lPSLz4LC12FW+t7kH6lGaytPqHMU/COfeWofgWy2tm59NVy7bTGJ1FHwp6m7Ub/VtInWtCHqIlVc5bcq2ZprI9wAUfCi+EpVFoM6eRCxXIts8GuwKJOaNgQELpdy8IzH/1kH9sE19DM=";
            })
                .AddInMemoryKeyStore();

            /*services.AddAuthentication("cookie")
               .AddCookie("cookie", options => { options.LoginPath = "/Identity/Account/Login"; });*/

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IPatientInfoService, PatientInfoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}