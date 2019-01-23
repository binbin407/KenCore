
using Ken.Models;
using Ken.Models.User;
using Microsoft.EntityFrameworkCore;

namespace KenCore.EF
{
    public class KylinDbContext: DbContext
    {
        public KylinDbContext(DbContextOptions<KylinDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<KenUser>()
                .ToTable("User");

            builder.Entity<FilmMaker>().ToTable("FilmMaker");
            builder.Entity<FilmMakerPhone>().ToTable("FilmMakerPhone");
        }

        public DbSet<KenUser> Users { get; set; }
        public DbSet<FilmMaker> FilmMakers { get; set; }
        public DbSet<FilmMakerPhone> FilmMakerPhones { get; set; }
    }
}
