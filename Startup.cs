using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.mocks;
using Shop.Data.Repository;
using Shop.Data.Models;

namespace Shop
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsattongs.json").Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddControllers();
            services.AddRazorPages();
            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env) 
        { 
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();

            app.UseStaticFiles();
            app.UseSession();

            /*app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller="Car", action="List" });

            });*/
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "categoryFilter",
                    pattern: "{controller=Car}/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
            });
            

            using var scope = app.ApplicationServices.CreateScope();
            AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
            DBObjects.Initial(content);
        }
    }
}
