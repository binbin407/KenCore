using Autofac;
using KenCore.Domain;
using KenCore.Module;

namespace KenCore.Mongo
{
    [DependsOn(typeof(KenKernelModule))]
    public class MongoModule:KenModule
    {
        public override void Init()
        {
            //泛型仓储注册
            ContainerBuilder.RegisterGeneric(typeof(RepositoryBase<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();
            ContainerBuilder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}
