using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KenCore.EF
{
    public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<KylinDbContext>
    {
        public KylinDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<KylinDbContext>();
            builder.UseNpgsql("UsedForMigrationsOnlyUntilClassLibraryBugIsFixed");

            return new KylinDbContext(builder.Options);
        }
    }
}
