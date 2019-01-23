using Ken.Models;
using System;
using System.Threading.Tasks;

namespace KenCore.EF.Repository
{
    public class FilmMakerRepository : IFilmMakerRepository
    {

        private readonly IContextFactory _dbContextFactory;

        public FilmMakerRepository(IContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Task<bool> Delete(FilmMaker filmMaker)
        {
            throw new NotImplementedException();
        }

        public Task<FilmMaker> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FilmMaker> Insert(FilmMaker filmMaker)
        {
            using (var context = _dbContextFactory.Create())
            {
                var fm = await context.FilmMakers.AddAsync(filmMaker);
                await context.SaveChangesAsync();
            }
            return filmMaker;
        }

        public Task<bool> Update(FilmMaker filmMaker)
        {
            throw new NotImplementedException();
        }
    }
}
