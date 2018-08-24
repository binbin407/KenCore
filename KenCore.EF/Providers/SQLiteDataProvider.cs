using KenCore.EF;
using KenCore.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KenCore.EF.Providers
{
    public class SQLiteDataProvider : IDataProvider
    {
        public DataProvider Provider { get; } = DataProvider.SQLite;

        public IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<KylinDbContext>(options =>
                options.UseSqlite(connectionString));

            return services;
        }

        public KylinDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KylinDbContext>();
            optionsBuilder.UseSqlite(connectionString);

            return new KylinDbContext(optionsBuilder.Options);
        }
    }
}