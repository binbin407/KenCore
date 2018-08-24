using Ken.Models;
using KenCore.Application;

namespace KenCore.EF.Repository
{
    public interface IUserRepository:IApplication
    {
        User GetById(int id);
    }
}
