using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestForASPCORE.Models;

namespace TestForASPCORE
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
            services.Add(new ServiceDescriptor(typeof(ProductCategoryContext), new ProductCategoryContext(Configuration.GetConnectionString("Conn"))));
            services.Add(new ServiceDescriptor(typeof(ProductContext), new ProductContext(Configuration.GetConnectionString("Conn"))));
            services.Add(new ServiceDescriptor(typeof(SupplierContext), new SupplierContext(Configuration.GetConnectionString("Conn"))));
            services.Add(new ServiceDescriptor(typeof(CustomerContext), new CustomerContext(Configuration.GetConnectionString("Conn"))));
            services.Add(new ServiceDescriptor(typeof(PurchaseContext), new PurchaseContext(Configuration.GetConnectionString("Conn"))));
            services.Add(new ServiceDescriptor(typeof(SalesContext), new SalesContext(Configuration.GetConnectionString("Conn"))));
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
                app.UseExceptionHandler("/Error");
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Category}/{action=Index}/{id?}");
            });
        }
    }
}
