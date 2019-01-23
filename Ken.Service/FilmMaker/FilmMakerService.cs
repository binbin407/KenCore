using Ken.Models;
using KenCore.Cache;
using KenCore.EF.Repository;
using log4net;
using System;
using System.Threading.Tasks;

namespace Ken.Service
{
    public class FilmMakerService : IFilmMakerService
    {
        private readonly ILog _log;
        private readonly ICache _cache;
        private readonly IFilmMakerRepository _filmMakerRepository;

        public FilmMakerService(ILog log, ICache cache, IFilmMakerRepository filmMakerRepository)
        {
            _log = log;
            _cache = cache;
            _filmMakerRepository = filmMakerRepository;
        }

        public async Task<FilmMaker> Insert(FilmMaker model)
        {
            try
            {
                return await _filmMakerRepository.Insert(model);
            }catch(Exception ex)
            {
                _log.Debug(ex);
                return null;
            }
            
        }
    }
}
