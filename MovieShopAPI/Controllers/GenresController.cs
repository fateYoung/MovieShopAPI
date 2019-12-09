using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public IActionResult GetAllGenres()
        {
            var genres = new[]
                         {
                             new {Id = 1, Name = "Action"},
                             new {Id = 2, Name = "Comedy"},
                             new {Id = 3, Name = "Thriller"}
                         };
            return Ok(genres);
        }
    }
}