using Ken.Models;
using KenCore.EF;
using KenCore.Module;
using KenCore.Redis;

namespace Ken.Service
{
    [DependsOn(typeof(KenModelModule), typeof(KenModelModule), typeof(KenEFModule), typeof(RedisModule))]
    public class ServiceModule : KenModule
    {
    }
}
