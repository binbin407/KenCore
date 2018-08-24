using Autofac;
using KenCore.Logging;
using KenCore.Module;

namespace KenCore
{
    public sealed class KenKernelModule: KenModule
    {
        public override void PreInit()
        {
            ContainerBuilder.RegisterModule(new Log4NetModule());
        }
    }
}
