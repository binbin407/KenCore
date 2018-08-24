using Autofac;
using KenCore.Dependency;
using System;

namespace KenCore.Configuration
{
    public static class KenCoreGlobalConfiguration
    {
        public static void Configuration(Action<KenCoreConfigurationPart> settings)
        {
            var pcp = new KenCoreConfigurationPart();
            settings(pcp);
            //自我注册
            IocManager.Instance.ContainerBuilder.RegisterInstance(pcp.Configuration).SingleInstance();
        }
    }
}
