using KenCore.Dependency;
using KenCore.Module;
using KenCore.Redis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenCore.Web
{
    public class WebModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public WebModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName, env.IsDevelopment());
        }

        public void PreInit()
        {
            var redisCacheHost = _appConfiguration.GetConnectionString("Redis");
        }
    }
}
