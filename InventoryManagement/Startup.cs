using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models.Contexts;
using InventoryManagement.Models.Services_BL.Inventories;
using InventoryManagement.Models.Services_BL.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connectionString = Configuration.GetConnectionString("MVC_API_Database");

            services.AddDbContext<API_DbContext>(opts => opts.UseSqlServer(connectionString));

            services.AddTransient<IAPI_DbContext, API_DbContext>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IInventoryService, InventoryService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.Use(async (context, next) =>
            {
                if (!Path.HasExtension(context.Request.Path.Value)
                && context.Request.HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest"
                && context.Request.Method.ToUpper() == "POST"
                && context.Request.Method.ToUpper() == "PUT"
                && context.Request.Method.ToUpper() == "DELETE")
                {
                    await context.Response.WriteAsync(File.ReadAllText(env.WebRootPath + "/index.html"));
                }

                await next();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
