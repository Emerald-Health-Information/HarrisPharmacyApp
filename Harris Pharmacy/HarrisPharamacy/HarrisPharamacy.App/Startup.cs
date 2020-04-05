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

using System;
using System.Linq;
using System.Net.Http;
using HarrisPharmacy.App.Areas.Identity;
using HarrisPharmacy.Data;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rsk.AspNetCore.Fido;

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
            /*services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AuthContextConnection")), (ServiceLifetime.Transient));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<AuthDbContext>();*/

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbConnectionString")), (ServiceLifetime.Transient));

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IPatientInfoService, PatientInfoService>();

            services.AddMvc();
            services.AddControllersWithViews();
            /*
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddFido(options =>
            {
                options.Licensee = "DEMO";
                options.LicenseKey = "eyJTb2xkRm9yIjowLjAsIktleVByZXNldCI6NiwiU2F2ZUtleSI6ZmFsc2UsIkxlZ2FjeUtleSI6ZmFsc2UsIlJlbmV3YWxTZW50VGltZSI6IjAwMDEtMDEtMDFUMDA6MDA6MDAiLCJhdXRoIjoiREVNTyIsImV4cCI6IjIwMjAtMDMtMjdUMDA6MDA6MDcuNTA3ODU3NiswMDowMCIsImlhdCI6IjIwMjAtMDItMjZUMDA6MDA6MDciLCJvcmciOiJERU1PIiwiYXVkIjo2fQ==.DYYbs0BypJJTdtkjXDGqtLRBI2L5nC8g4vzBh9zeW/mZNkqyPJpF1JxDr+qz4HyIxD1WGlQZXlU1n6hskN4vA2ozIS25MCMHSPTADX1e92iecUOFWgeTbqx/ai5VDykjv2TQ7TefF0Y1OGo5POgMeghkeOGZHXoaTO5XTsZyDt6QqebVCB1QkPjjKhgWEzg+M0XEM1RB57nC8CjE6xP+i6PVE0GQDyZUzykAmzgtF7E/LhWvSus2ATpne0bTqg+9Ltyla4u10sG5KDjkukm/0Qenqix4y3rVLts8CaWuN2sceeWUxZNx7HoWP8lM/XWsBMvof5g/aKiL7LIUxhEctHJaSc4QmT90hSGgeEDvkdbh5uwbL9NhCxv6z56Dt3sK5OlMerULM3+o4/l/Jt8zu6RBy4oeAiMyrAUFAXuCdjG6DerFNbOdF6zKIhBoYrdaSx871SFFTZ9YBDHRoBGwptbWwo1jsRXY9DpIu+t1mP+1HleZycUO32R4XuVDy4ccfOYpv9lMF/lMwN9LM1bol85uCZEN6u25lPSLz4LC12FW+t7kH6lGaytPqHMU/COfeWofgWy2tm59NVy7bTGJ1FHwp6m7Ub/VtInWtCHqIlVc5bcq2ZprI9wAUfCi+EpVFoM6eRCxXIts8GuwKJOaNgQELpdy8IzH/1kH9sE19DM=";
            })
                .AddEntityFrameworkStore(options => options.UseSqlServer(
                    Configuration.GetConnectionString("AuthContextConnection"), sql => sql.MigrationsAssembly(migrationsAssembly)));
            */
            services.AddFido(options =>
            {
                options.Licensee = "DEMO";
                options.LicenseKey = " eyJTb2xkRm9yIjowLjAsIktleVByZXNldCI6NiwiU2F2ZUtleSI6ZmFsc2UsIkxlZ2FjeUtleSI6ZmFsc2UsIlJlbmV3YWxTZW50VGltZSI6IjAwMDEtMDEtMDFUMDA6MDA6MDAiLCJhdXRoIjoiREVNTyIsImV4cCI6IjIwMjAtMDUtMDJUMDE6MDA6MDUuOTk0MTI5MiswMTowMCIsImlhdCI6IjIwMjAtMDQtMDJUMDA6MDA6MDUiLCJvcmciOiJERU1PIiwiYXVkIjo2fQ==.ASOAUkv9FRLwW7OBNtKIDT+G3pr/oMNmNA7g0w6tNbiInFkMkLxc+tBU/yF7S9smLYIuylw9qaVuLVoxtwSmb5/5psHs4Emc/mPqXcwHszNzl+tKLA2KNa2ngszAqNQAfRkHn0wm5RU5suHUlCs1BSw/fzCxSqATIkQnNrIxPOW58Hlo7daMEAproRUPgsZIuveLCyM3yNm3WVdsuJIifNbsG9SakTnndsU/bZJnFaeV3DJ3G8MgBeJbc6R4HQLAG6dvwxwegBAsU1bsfWZm26ntMfkrIRrnB9BBBnDm4mrIj6R8pHdiDcW95quzT/7xmzPd24wvCowuAvI7V8vJkskdTGRAfXUGknou22HmvofHfDLpbcy5bJJ2rCtzYdp4790wrV1PjVqXaNUbuTxtPtFYJhZpRHr5wOa7kF7s0hH6PcQOmK6CzKkyxE61fTdzXIXk0k9spinFb4RbsG8txpa1oKvtd8DRT2N3D768KIUaNWVT3Wb5McL8lJMvpphDgsg6TSHflqkxWAmq9tBVqupFxFBumKHRvWk1XwJPGHlaumanookklrA6lHv7C92PgkFIwKF8nCgTmfu86Dz52HcR/lOYJFv85tDz3fAG9BdFl6iCr3TR+s6iOzrgsKsuXxWo1ePspT8CWmStj3iDFW9EAMiF0FuossfdE8kGDVs=";
            })
                .AddInMemoryKeyStore();

            // Server Side Blazor doesn't register HttpClient by default
            if (services.All(x => x.ServiceType != typeof(HttpClient)))
            {
                // Setup HttpClient for server side in a client side compatible fashion
                services.AddScoped<HttpClient>(s =>
                {
                    // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.
                    var uriHelper = s.GetRequiredService<NavigationManager>();
                    return new HttpClient
                    {
                        BaseAddress = new Uri("https://localhost:44306/")
                    };
                });
            }

            services.AddAuthentication("cookie")
                .AddCookie("cookie", options => { options.LoginPath = "/Home/StartLogin"; });
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}