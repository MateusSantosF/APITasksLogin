using Login.Models;
using Login.Services.Context;
using Login.Services.UserRepository.interfaces;

namespace Login.Services.UserRepository
{
    public class UserRepository:IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public bool ExistsUserEmail(string email)
        {
            return _userContext.Users.Any(u => u.Email == email);
        }

        public List<User> GetAllUsers()
        {
            return _userContext.Users.ToList();
        }

        public User? GetUser(string email, string password)
        {
            return _userContext.Users.Where(user => user.Email.Equals(email) && user.Password.Equals(password)).FirstOrDefault();
        }

        public async Task<bool> InsertUser(User user)
        {
            await _userContext.AddAsync(user);
            return await _userContext.SaveChangesAsync() > 0;
        }
    }
}
