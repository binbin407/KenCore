using Ken.Models;
using Ken.Models.User;
using KenCore.Application;
using System.Threading.Tasks;

namespace Ken.Service
{
    public interface IUserService: IApplication
    {
        KenUser FirstOrDefaultAsync(int id);
        Task<KenUser> CreateUser(KenUser model);
    }
}
