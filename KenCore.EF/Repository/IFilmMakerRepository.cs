using Ken.Models;
using KenCore.Application;
using System.Threading.Tasks;

namespace KenCore.EF.Repository
{
    public interface IFilmMakerRepository: IApplication
    {
        Task<FilmMaker> Insert(FilmMaker filmMaker);
        Task<FilmMaker> GetById(int id);
        Task<bool> Update(FilmMaker filmMaker);
        Task<bool> Delete(FilmMaker filmMaker);
    }
}
