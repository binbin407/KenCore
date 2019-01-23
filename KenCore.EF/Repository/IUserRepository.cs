using Ken.Models;
using Ken.Models.User;
using KenCore.Application;
using System.Threading.Tasks;

namespace KenCore.EF.Repository
{
    public interface IUserRepository:IApplication
    {
        Task<KenUser> InsertAsync(KenUser user);
        KenUser GetById(int id);
    }
}
