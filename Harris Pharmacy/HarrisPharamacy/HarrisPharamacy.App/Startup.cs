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
using Microsoft.OpenApi.Models;

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

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IPatientInfoService, PatientInfoService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HarrisPharmacyApp API", Version = "v1" });
            });

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HarrisPharmacyApp API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}