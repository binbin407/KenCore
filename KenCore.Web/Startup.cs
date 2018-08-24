using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Ken.Service;
using KenCore.Configuration;
using KenCore.EF.Configuration;
using KenCore.Redis;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KenCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName, env.IsDevelopment());
        }
        private readonly IConfigurationRoot _appConfiguration;
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<Data>(c => {
                c.Provider = (DataProvider)Enum.Parse(
                    typeof(DataProvider),
                    Configuration.GetSection("Data")["Provider"]);
            });

            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(LogManager.CreateRepository("NETCoreRepository"),logCfg);
            Bootstrapper bootstrappe = Bootstrapper.Create<ServiceModule>();
            bootstrappe.IocManager.ContainerBuilder.Populate(services);
            var mongo = _appConfiguration.GetConnectionString("KenData");
            var re = _appConfiguration.GetConnectionString("Redis");
            KenCoreGlobalConfiguration.Configuration(settings =>
            {
                settings
                .UseRedisDataBase(_appConfiguration.GetConnectionString("Redis"))
                .MasterDataBases("KenData", _appConfiguration.GetConnectionString("KenData"));
            });
            

            bootstrappe.Initialize();

            return new AutofacServiceProvider(bootstrappe.IocManager.Container);

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
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
