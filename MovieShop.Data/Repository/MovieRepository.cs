using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using MovieShop.Data.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
        {

        }
        public async Task<IEnumerable<Movie>> GetMovieByGenreIdAsync(int genreId)
        {
            return await _dbContext.Movies.Where(m => m.MovieGenres.Any(g => g.GenreId == genreId)).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetTopFavoritedMoviesAsync()
        {
            var movieFavorited = await _dbContext.Favorites.GroupBy(f => f.MovieId)
                                                     .Select(mf => new { MovieId = mf.Key, Count = mf.Count() })
                                                     .OrderByDescending(mf1 => mf1.Count).Take(20).ToListAsync();
            var movies = new List<Movie>();
            foreach (var item in movieFavorited)
            {
                movies.Add(await _dbContext.Movies.Where(m => m.Id == item.MovieId).FirstOrDefaultAsync());
            }

            return movies;
        }

        public async Task<IEnumerable<Movie>> GetTopPurchasedMoviesAsync()
        {
            var moviePurchased = await _dbContext.Purchases.GroupBy(p => p.MovieId)
                                                     .Select(mp => new { MovieId = mp.Key, Count = mp.Count() })
                                                     .OrderByDescending(mp1 => mp1.Count).Take(20).ToListAsync();
            var movies = new List<Movie>();
            foreach (var item in moviePurchased)
            {
                movies.Add(await _dbContext.Movies.Where(m => m.Id == item.MovieId).FirstOrDefaultAsync());
            }

            return movies;
        }

        public async Task<IEnumerable<Movie>> GetTopRatingMoviesAsync()
        {
            var movieReview = await _dbContext.Reviews.GroupBy(r => r.MovieId)
                                                .Select(mr => new { MovieId = mr.Key, AvgReview = mr.Average(r => r.Rating) })
                                                .OrderByDescending(mr1 => mr1.AvgReview).Take(20).ToListAsync();
            var movies = new List<Movie>();
            foreach (var movie in movieReview)
            {
                movies.Add(await _dbContext.Movies.Where(m => m.Id == movie.MovieId).FirstOrDefaultAsync());
            }

            return movies;
        }

        public async Task<IEnumerable<Movie>> GetTopRevenueMoviesAsync()
        {
            return await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(20).ToListAsync();
        }
    }
}
