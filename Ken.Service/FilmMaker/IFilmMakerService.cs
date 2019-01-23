using KenCore.Application;
using System.Threading.Tasks;
using Ken.Models;
namespace Ken.Service
{
    public interface IFilmMakerService: IApplication
    {
        Task<FilmMaker> Insert(FilmMaker model);
    }
}
