using Ken.Models;
using KenCore.Application;
using System.Threading.Tasks;

namespace Ken.Service
{
    public interface IUserService: IApplication
    {
        User FirstOrDefaultAsync(int id);
        Task<User> CreateUser(User model);
    }
}
