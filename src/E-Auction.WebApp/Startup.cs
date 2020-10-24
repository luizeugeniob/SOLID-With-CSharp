using EAuction.WebApp.Data;
using EAuction.WebApp.Data.EFCore;
using EAuction.WebApp.Services;
using EAuction.WebApp.Services.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EAuction.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAuctionDao, AuctionDao>();
            services.AddTransient<ICategoryDao, CategoryDao>();

            services.AddTransient<IProductService, DefaultProductService>();
            services.AddTransient<IAdminService, DefaultAdminService>();

            services.AddDbContext<AppDbContext>();

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => 
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
