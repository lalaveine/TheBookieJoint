﻿using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using TheBookieJoint.Models;

namespace TheBookieJoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration) {
            Configuration = configuration;

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU");
        } 
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration["Data:TheBookieJointProducts:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseNpgsql(Configuration["Data:TheBookieJointIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {

                routes.MapRoute(
                    name: null,
                    template: "/Admin/Orders/sort-{sortOrder}/Page{productPage:int}",
                    defaults: new { controller = "Order", action = "List"});

                routes.MapRoute(
                    name: null,
                    template: "/Admin/Orders/Page{productPage:int}",
                    defaults: new { controller = "Order", action = "List"});

                routes.MapRoute(
                    name: null,
                    template: "/Admin/Orders",
                    defaults: new { controller = "Order", action = "List"});    

                routes.MapRoute(
                    name: null,
                    template: "Admin/sort-{sortOrder}/Page{productPage:int}",
                    defaults: new { controller = "Admin", action = "Index"});         

                routes.MapRoute(
                    name: null,
                    template: "Admin/Page{productPage:int}",
                    defaults: new { controller = "Admin", action = "Index" });                
                
                routes.MapRoute(
                    name: null,
                    template: "Admin/sort-{sortOrder}",
                    defaults: new { controller = "Admin", action = "Index" });
                
                routes.MapRoute(
                    name: null,
                    template: "Admin",
                    defaults: new { controller = "Admin", action = "Index" });
                
                routes.MapRoute(
                    name: null,
                    template: "genre-{genre}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" });

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });
                
                routes.MapRoute(
                    name: null,
                    template: "genre-{genre}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });
                
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
            
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
