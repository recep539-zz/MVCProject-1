using AdvancedRepository.DTOs;
using AdvancedRepository.Models;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.Repository.Classes;
using AdvancedRepository.Repository.Interfaces;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository
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
            services.AddControllersWithViews();
            services.AddDbContext<CompanyContext>(options => options.UseSqlServer("Server=DESKTOP-F6HHAUL\\SQLEXPRESS;Database=DBCompanyCore-1;Trusted_Connection=True;"));
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });           
            services.AddScoped<IUnity, Unity>();
            services.AddScoped<CategoryModel>();
            services.AddScoped<CityModel>();
            services.AddScoped<CountyModel>();
            services.AddScoped<CustomerModel>();
            services.AddScoped<EmployeeModel>();
            services.AddScoped<ProductModel>();
            services.AddScoped<SupplierModel>();
            services.AddScoped<UnitModel>();
            services.AddScoped<FatMasterModel>();
            services.AddScoped<FatDetailModel>();
            services.AddScoped<LoginModel>();
            services.AddScoped<Users>();
            services.AddScoped<BasketModel>();
            services.AddScoped<List<BasketList>>();
            services.AddScoped<BasketList>();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession(); //.NET CORE SESS?ON M?CROSOFT S?TES?NDEN ALDIK.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
