using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monafasati.Data;
using Monafasati.Data.Services;

namespace Monafasati.Web
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
                                                                                                                              
            services.AddDbContextPool<MonafasatiDbContext>(opsion => { opsion.UseSqlServer(Configuration.GetConnectionString("DefultConnection")); });
            services.AddIdentity<IdentityUser,IdentityRole>()
                .AddEntityFrameworkStores<MonafasatiDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddScoped<IStatuData, StatuData>();
            services.AddScoped<IMonafasaData, MonafasaData>();
            services.AddScoped<IEngineerData, EngineerData>();
            services.AddScoped<IItemData, ItemData>();
            services.AddScoped<IArchiveData, ArchiveData>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Mobile}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
