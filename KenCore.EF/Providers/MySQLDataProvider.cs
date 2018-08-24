using KenCore.EF;
using KenCore.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KenCore.EF.Providers
{
    public class MySQLDataProvider : IDataProvider
    {
        public DataProvider Provider { get; } = DataProvider.MySQL;

        public IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<KylinDbContext>(options => 
                options.UseMySql(connectionString));

            return services;
        }

        public KylinDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KylinDbContext>();
            optionsBuilder.UseMySql(connectionString);

            return new KylinDbContext(optionsBuilder.Options);
        }
    }
}