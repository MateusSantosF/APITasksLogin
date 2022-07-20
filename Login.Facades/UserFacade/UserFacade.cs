using Login.Facades.UserFacade.interfaces;
using Login.Models;
using Login.Services.UserRepository.interfaces;

namespace Login.Facades.UserFacade
{
    public class UserFacade:IUserFacade
    {

        private readonly IUserRepository _userRepository;

        public UserFacade(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? GetUser(string email, string password)
        {
            return _userRepository.GetUser(email, password);
        }

        public async Task<bool> SignUpUserAsync(string email, string password, string name)
        {

            return await _userRepository.InsertUser(new User() { Id = Guid.NewGuid().ToString(),Email = email, Password = password, Name = name });
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
