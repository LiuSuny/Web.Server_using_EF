using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkBasic
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
            //Add applicationdbcontext to DI
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region DbContext connection Non-standard way
            //WAY OF CONNECTING TO OUR DATABASE USING DBCONTEXT IN NON-STANDARD WAY BUT SIMPLE WAY TO UNDERSTAND HOW
            //HOW DBCONTEXT WORK
            //using (var context = new ApplicationDbContext())
            //{
            //    //Making we have a database
            //    context.Database.EnsureCreated();

            //    if(!context.Settings.Any())
            //    {
            //        context.Settings.Add(new SettingsDataModel
            //        {                      
            //           Name = "BackgroundColor",
            //           Value  = "Red"
            //        });

            //        var SettingsLocally = context.Settings.Local.Count();
            //        var SettingsDatabase = context.Settings.Count();

            //        var firstSettingslocal = context.Settings.Local.FirstOrDefault();
            //        var firstSettingsDatabase = context.Settings.FirstOrDefault();

            //        context.SaveChanges();

            //        SettingsLocally = context.Settings.Local.Count();
            //        SettingsDatabase = context.Settings.Count();

            //        firstSettingslocal = context.Settings.Local.FirstOrDefault();
            //        firstSettingsDatabase = context.Settings.FirstOrDefault();
            //    }
            //} 
            #endregion

           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            // Store instance  of the DI  service provider  so our application can access  it anywhere
            //IOCContainer.Provider = (ServiceProvider)serviceProvider;

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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "aboutPage",
                   template: "more",
                   defaults: new { controller = "About", action = "TellMeMore" });
            });
        }
    }
}
