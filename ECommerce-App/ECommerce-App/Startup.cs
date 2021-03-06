using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Data;
using ECommerce_App.Models;
using ECommerce_App.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity;
using ECommerce_App.Models.Interface;

namespace ECommerce_App
{
    public class Startup
    {
        public IConfiguration Config { get; }

        public Startup(IConfiguration config)
        {
            Config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(Config.GetConnectionString("StoreConnection"));
            });

            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(Config.GetConnectionString("UserConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<UserDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin));
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 2;
            });

            services.AddTransient<IFlummeryInventory, FlummeryInventoryManagement>();
            services.AddTransient<IImage, UploadImageService>();
            services.AddTransient<IEmail, EmailService>();
            services.AddTransient<ICart, CartService>();
            services.AddTransient<ICartItem, CartItemService>();
            services.AddTransient<IPaymentHandler, PaymentHandlingService>();
            services.AddTransient<IOrder, OrderService>();
            services.AddTransient<IOrderItem, OrderItemService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            ConfigureImp(app, env, serviceProvider).Wait();
        }

        /// <summary>
        /// Private method to asynchronously set up the HTTP request pipeline.
        /// </summary>
        private async Task ConfigureImp(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await RoleInitializer.SeedAdmin(serviceProvider, userManager, Config);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
