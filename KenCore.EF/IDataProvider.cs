using KenCore.Dependency;
using KenCore.EF.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KenCore.EF
{
    public interface IDataProvider: ISingletonDependency
    {
        DataProvider Provider { get; }
        IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString);
        KylinDbContext CreateDbContext(string connectionString);
    }
}
