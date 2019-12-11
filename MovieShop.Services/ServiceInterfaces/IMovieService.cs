using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetTopGrossingMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<IEnumerable<Movie>> GetMoviesByGenreIdAsync(int genreId);
        Task<IEnumerable<Movie>> GetTopRatedMoviesAsync();
        Task<IEnumerable<Movie>> GetTop20PurchasedMoviesAsync();
        Task<IEnumerable<Movie>> GetTop20FavoritedMoviesAsync();
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
    }
}
