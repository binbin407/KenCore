using KenCore.Dependency;

namespace KenCore.EF
{
    public interface IContextFactory: ISingletonDependency
    {
        KylinDbContext Create();
    }
}
