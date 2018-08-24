using KenCore.Module;

namespace KenCore.Redis
{
    [DependsOn(typeof(KenKernelModule))]
    public class RedisModule : KenModule
    {
    }
}
