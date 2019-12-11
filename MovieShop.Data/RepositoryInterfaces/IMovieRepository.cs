using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.RepositoryInterfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRevenueMoviesAsync();
        Task<IEnumerable<Movie>> GetMovieByGenreIdAsync(int genreId);
        Task<IEnumerable<Movie>> GetTopRatingMoviesAsync();
        Task<IEnumerable<Movie>> GetTopPurchasedMoviesAsync();
        Task<IEnumerable<Movie>> GetTopFavoritedMoviesAsync();
    }
}
