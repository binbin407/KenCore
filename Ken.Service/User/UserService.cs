using Ken.Models;
using Ken.Models.User;
using KenCore.Cache;
using KenCore.EF.Repository;
using log4net;
using System;
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

        public async Task<KenUser> CreateUser(KenUser model)
        {
            try
            {
                return await _userRepository.InsertAsync(model);
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
                return null;
            }
        }

        public KenUser FirstOrDefaultAsync(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
