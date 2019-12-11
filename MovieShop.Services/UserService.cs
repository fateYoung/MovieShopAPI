using MovieShop.Core.Entities;
using MovieShop.Data.RepositoryInterfaces;
using MovieShop.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        public UserService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }
        public async Task<User> CreateUserAsync(string userName, string password, string firstName, string lastName, int[] roles = null)
        {
            var user = await _userRepository.GetUserByUserNameAsync(userName);
            if (user != null)
            {
                return null;
            }

            var salt = _cryptoService.CreateSalt();
            var hashedPassword = _cryptoService.HashPassword(password, salt);

            var dbUser = new User
            {
                Email = userName,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = firstName,         
                LastName = lastName
            };

            return await _userRepository.AddAsync(dbUser);            
        }

        public Task<IEnumerable<User>> GetAllUsersAsync(int pageSize = 30, int pageIndex = 0, string name = "")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Favorite>> GetFavoriteMoviesByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> GetPurchasedMoviesByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetReviewedMoviesByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRole>> GetUserRolesAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUsersCountAsync(string name = "")
        {
            throw new NotImplementedException();
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUserNameAsync(username);
            if (user == null)
            {
                return null;
            }

            var hashedPassword = _cryptoService.HashPassword(password, user.Salt);
            if (hashedPassword == user.HashedPassword)
            {
                return user;
            }

            return null;
        }
    }
}
