using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using MovieShop.Data.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == username);
        }

        public async Task<User> GetUserDetailsAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<IEnumerable<Favorite>> GetUserFavoriteMoviesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> GetUserPurchasedMoviesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetUserReviewedMoviesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRole>> GetUserRolesAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync(int pageSize = 30, int pageIndex = 0, string name = "")
        {
            throw new NotImplementedException();
        }
    }
}
