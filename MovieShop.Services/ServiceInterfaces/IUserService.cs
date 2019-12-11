using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services.ServiceInterfaces
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
        Task<User> CreateUserAsync(string userName, string password, string firstName, string lastName, int[] roles = null);
        Task<User> GetUserDetailsAsync(int id);
        Task<User> GetUserAsync(string username);
        Task<int> GetUsersCountAsync(string name = "");
        Task<IEnumerable<User>> GetAllUsersAsync(int pageSize = 30, int pageIndex = 0, string name = "");
        Task<IEnumerable<UserRole>> GetUserRolesAsync(string username);
        Task<IEnumerable<Favorite>> GetFavoriteMoviesByUserIdAsync(int id);
        Task<IEnumerable<Purchase>> GetPurchasedMoviesByUserIdAsync(int id);
        Task<IEnumerable<Review>> GetReviewedMoviesByUserIdAsync(int id);
    }
}
