using Autofac;
using KenCore;
using KenCore.Cache;
using KenCore.Configuration;
using System;
using Xunit;

namespace KenCoreTest
{
    public class UnitTest1
    {

        public static Bootstrapper Bootstrapper { get; } = Bootstrapper.Create<KenCoreTestModule>();

        public UnitTest1()
        {
            //ÅäÖÃÊÖ½Å¼Ü
            KenCoreGlobalConfiguration.Configuration(settings =>
            {
                settings.UseRedisDataBase("192.168.10.222:6379");
            });
            Bootstrapper.Initialize();
        }

        [Fact]
        public void Test1()
        {
            var cache = Bootstrapper.IocManager.Container.Resolve<ICache>();
            cache.Set("111", "222");
            var xx = cache.Get<string>("111");
            Assert.Equal("222", xx);
        }
    }
}
