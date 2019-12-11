using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUserNameAsync(string username);
        Task<User> GetUserDetailsAsync(int id);
        Task<IEnumerable<UserRole>> GetUserRolesAsync(string username);
        Task<IEnumerable<Favorite>> GetUserFavoriteMoviesAsync(int id);
        Task<IEnumerable<Purchase>> GetUserPurchasedMoviesAsync(int id);
        Task<IEnumerable<Review>> GetUserReviewedMoviesAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync(int pageSize = 30, int pageIndex = 0, string name = "");
    }
}
