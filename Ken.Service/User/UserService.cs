using Ken.Models;
using KenCore.Cache;
using KenCore.EF.Repository;
using log4net;
using System.Threading.Tasks;

namespace Ken.Service
{
    public class UserService : IUserService
    {
        private readonly ILog _log;
        private readonly ICache _cache;
        private readonly IUserRepository _userRepository;

        public UserService(ILog log,ICache cache, IUserRepository userRepository)
        {
            _log = log;
            _cache = cache;
            _userRepository = userRepository;
        }

        public User FirstOrDefaultAsync(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
