using MovieShop.Core.Entities;
using MovieShop.Data.RepositoryInterfaces;
using MovieShop.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MovieShop.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return genres.OrderBy(g => g.Name).ToList();
        }
    }
}
