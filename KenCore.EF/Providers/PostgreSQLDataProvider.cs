using KenCore.EF;
using KenCore.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KenCore.EF.Providers
{
    public class PostgreSQLDataProvider : IDataProvider
    {
        public DataProvider Provider { get; } = DataProvider.PostgreSQL;

        public IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<KylinDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }

        public KylinDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KylinDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new KylinDbContext(optionsBuilder.Options);
        }
    }
}