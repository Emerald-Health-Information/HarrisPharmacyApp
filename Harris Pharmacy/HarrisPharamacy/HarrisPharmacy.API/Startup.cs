using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.App.Areas.Identity;
using HarrisPharmacy.Data;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HarrisPharmacy.API
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

            services.AddControllers();
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IPatientInfoService, PatientInfoService>();

            services.AddFido(options =>
                {
                    options.Licensee = "DEMO";
                    options.LicenseKey = " eyJTb2xkRm9yIjowLjAsIktleVByZXNldCI6NiwiU2F2ZUtleSI6ZmFsc2UsIkxlZ2FjeUtleSI6ZmFsc2UsIlJlbmV3YWxTZW50VGltZSI6IjAwMDEtMDEtMDFUMDA6MDA6MDAiLCJhdXRoIjoiREVNTyIsImV4cCI6IjIwMjAtMDUtMDJUMDE6MDA6MDUuOTk0MTI5MiswMTowMCIsImlhdCI6IjIwMjAtMDQtMDJUMDA6MDA6MDUiLCJvcmciOiJERU1PIiwiYXVkIjo2fQ==.ASOAUkv9FRLwW7OBNtKIDT+G3pr/oMNmNA7g0w6tNbiInFkMkLxc+tBU/yF7S9smLYIuylw9qaVuLVoxtwSmb5/5psHs4Emc/mPqXcwHszNzl+tKLA2KNa2ngszAqNQAfRkHn0wm5RU5suHUlCs1BSw/fzCxSqATIkQnNrIxPOW58Hlo7daMEAproRUPgsZIuveLCyM3yNm3WVdsuJIifNbsG9SakTnndsU/bZJnFaeV3DJ3G8MgBeJbc6R4HQLAG6dvwxwegBAsU1bsfWZm26ntMfkrIRrnB9BBBnDm4mrIj6R8pHdiDcW95quzT/7xmzPd24wvCowuAvI7V8vJkskdTGRAfXUGknou22HmvofHfDLpbcy5bJJ2rCtzYdp4790wrV1PjVqXaNUbuTxtPtFYJhZpRHr5wOa7kF7s0hH6PcQOmK6CzKkyxE61fTdzXIXk0k9spinFb4RbsG8txpa1oKvtd8DRT2N3D768KIUaNWVT3Wb5McL8lJMvpphDgsg6TSHflqkxWAmq9tBVqupFxFBumKHRvWk1XwJPGHlaumanookklrA6lHv7C92PgkFIwKF8nCgTmfu86Dz52HcR/lOYJFv85tDz3fAG9BdFl6iCr3TR+s6iOzrgsKsuXxWo1ePspT8CWmStj3iDFW9EAMiF0FuossfdE8kGDVs=";
                })
                .AddInMemoryKeyStore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}