using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Entities;
using MovieShop.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController: ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [Route("top20rating")]
        public async Task<IActionResult> GetTop20RatingMoviesAsync()
        {
            var movies =  await _movieService.GetTopRatedMoviesAsync();
            return Ok(movies);
        }

        [Route("top20revenue")]
        public async Task<IActionResult> GetTop20GrossingMoviesAsync()
        {
            var movies = await _movieService.GetTopGrossingMoviesAsync();
            return Ok(movies);
        }

        [Route("top30revenue")]
        public async Task<IActionResult> GetTop30GrossingMoviesAsync()
        {
            var movies = await _movieService.GetTopGrossingMoviesAsync();
            return Ok(movies);
        }

        [Route("top20favorite")]
        public async Task<IActionResult> Get20TopFavoriteMoviesAsync()
        {
            var movies = await _movieService.GetTop20FavoritedMoviesAsync();
            return Ok(movies);
        }

        [Route("top20purchase")]
        public async Task<IActionResult> Get20TopPurchasedMoviesAsync()
        {
            var movies = await _movieService.GetTop20PurchasedMoviesAsync();
            return Ok(movies);
        }

        [Route("genre/{id}")]
        public async Task<IActionResult> GetMovieByGenreId(int id)
        {
            var movies = await _movieService.GetMoviesByGenreIdAsync(id);
            return Ok(movies);
        }

        public async Task<IActionResult> GetAllofTheMoviesAsync()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }
    }
}
