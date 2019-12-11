using MovieShop.Core.Entities;
using MovieShop.Data.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Data.Repository
{
    public class GenreRepository: Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext): base(dbContext)
        {

        }
    }
}
