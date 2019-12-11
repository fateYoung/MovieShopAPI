using MovieShop.Core.Entities;
using MovieShop.Data.RepositoryInterfaces;
using MovieShop.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreIdAsync(int genreId)
        {
            return await _movieRepository.GetMovieByGenreIdAsync(genreId);
        }

        public async Task<IEnumerable<Movie>> GetTop20FavoritedMoviesAsync()
        {
            return await _movieRepository.GetTopFavoritedMoviesAsync();
        }

        public async Task<IEnumerable<Movie>> GetTop20PurchasedMoviesAsync()
        {
            return await _movieRepository.GetTopPurchasedMoviesAsync();
        }

        public async Task<IEnumerable<Movie>> GetTopGrossingMoviesAsync()
        {
            return await _movieRepository.GetTopRevenueMoviesAsync();
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMoviesAsync()
        {
            return await _movieRepository.GetTopRatingMoviesAsync();
        }
    }
}
