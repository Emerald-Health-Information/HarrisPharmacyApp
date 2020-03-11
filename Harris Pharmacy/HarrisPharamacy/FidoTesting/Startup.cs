using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FidoTesting
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc();
         services.AddControllersWithViews();

         services.AddFido(options =>
         {
            options.Licensee = "DEMO";
            options.LicenseKey = "eyJTb2xkRm9yIjowLjAsIktleVByZXNldCI6NiwiU2F2ZUtleSI6ZmFsc2UsIkxlZ2FjeUtleSI6ZmFsc2UsIlJlbmV3YWxTZW50VGltZSI6IjAwMDEtMDEtMDFUMDA6MDA6MDAiLCJhdXRoIjoiREVNTyIsImV4cCI6IjIwMjAtMDMtMjdUMDA6MDA6MDcuNTA3ODU3NiswMDowMCIsImlhdCI6IjIwMjAtMDItMjZUMDA6MDA6MDciLCJvcmciOiJERU1PIiwiYXVkIjo2fQ==.DYYbs0BypJJTdtkjXDGqtLRBI2L5nC8g4vzBh9zeW/mZNkqyPJpF1JxDr+qz4HyIxD1WGlQZXlU1n6hskN4vA2ozIS25MCMHSPTADX1e92iecUOFWgeTbqx/ai5VDykjv2TQ7TefF0Y1OGo5POgMeghkeOGZHXoaTO5XTsZyDt6QqebVCB1QkPjjKhgWEzg+M0XEM1RB57nC8CjE6xP+i6PVE0GQDyZUzykAmzgtF7E/LhWvSus2ATpne0bTqg+9Ltyla4u10sG5KDjkukm/0Qenqix4y3rVLts8CaWuN2sceeWUxZNx7HoWP8lM/XWsBMvof5g/aKiL7LIUxhEctHJaSc4QmT90hSGgeEDvkdbh5uwbL9NhCxv6z56Dt3sK5OlMerULM3+o4/l/Jt8zu6RBy4oeAiMyrAUFAXuCdjG6DerFNbOdF6zKIhBoYrdaSx871SFFTZ9YBDHRoBGwptbWwo1jsRXY9DpIu+t1mP+1HleZycUO32R4XuVDy4ccfOYpv9lMF/lMwN9LM1bol85uCZEN6u25lPSLz4LC12FW+t7kH6lGaytPqHMU/COfeWofgWy2tm59NVy7bTGJ1FHwp6m7Ub/VtInWtCHqIlVc5bcq2ZprI9wAUfCi+EpVFoM6eRCxXIts8GuwKJOaNgQELpdy8IzH/1kH9sE19DM=";
         })
             .AddInMemoryKeyStore();

         services.AddAuthentication("cookie")
             .AddCookie("cookie", options => { options.LoginPath = "/Home/StartLogin"; });
      }

      public void Configure(IApplicationBuilder app)
      {
         app.UseDeveloperExceptionPage();

         app.UseHttpsRedirection();

         app.UseStaticFiles();
         app.UseRouting();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
      }
   }
}
