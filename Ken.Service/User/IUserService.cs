using Ken.Models;
using KenCore.Application;

namespace Ken.Service
{
    public interface IUserService: IApplication
    {
        User FirstOrDefaultAsync(int id);
    }
}
