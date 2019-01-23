using Ken.Models;
using KenCore.Application;
using System.Threading.Tasks;

namespace KenCore.EF.Repository
{
    public interface IUserRepository:IApplication
    {
        Task<User> InsertAsync(User user);
        User GetById(int id);
    }
}
