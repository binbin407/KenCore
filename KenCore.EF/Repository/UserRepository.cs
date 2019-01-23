using Ken.Models;
using System.Linq;
using System.Threading.Tasks;

namespace KenCore.EF.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IContextFactory _dbContextFactory;

        public UserRepository(IContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public User GetById(int id)
        {
            using (var context = _dbContextFactory.Create())
            {
                var dbEntity = context.Users.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
                return dbEntity != null ? dbEntity : null;
            }
        }

        public async Task<User> InsertAsync(User user)
        {
            using (var context = _dbContextFactory.Create())
            {
                var result = await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
            return user;
        }
    }
}
