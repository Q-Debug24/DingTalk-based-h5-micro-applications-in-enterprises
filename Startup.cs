using DingDingPuls.Controllers;
using DingDingPuls.Datas;
using DingDingPuls.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace DingDingPuls
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
            services.AddScoped<IRepairedEFService, RepairedEFService>();
            services.AddScoped<ICheckEFService, CheckEFService>();
            services.AddDbContext<DingDingDBContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddTransient<DingTalkController>();

            services.AddHostedService<AutoTaskService>();
        }

        //   This method gets called by the runtime.  Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //   The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    RequestPath = "/node_modules",
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules"))
            //});
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=homepage}/{id?}");
            });
        }
    }
}