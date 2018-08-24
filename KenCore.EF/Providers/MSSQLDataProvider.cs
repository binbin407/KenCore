using KenCore.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KenCore.EF.Providers
{
    public class MSSQLDataProvider : IDataProvider
    {
        public DataProvider Provider { get; } = DataProvider.MSSQL;

        public IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<KylinDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public KylinDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KylinDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new KylinDbContext(optionsBuilder.Options);
        }
    }
}