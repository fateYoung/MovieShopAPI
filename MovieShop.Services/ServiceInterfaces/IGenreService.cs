using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
    }
}
