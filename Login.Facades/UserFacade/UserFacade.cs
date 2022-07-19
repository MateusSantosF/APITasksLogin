using Login.Facades.UserFacade.interfaces;
using Login.Models.User;
using Login.Services.UserRepository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Facades.UserFacade
{
    public class UserFacade:IUserFacade
    {

        private readonly IUserRepository _userRepository;

        public UserFacade(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User> GetUserAsync(string email, string password)
        {
            return await Task.Run(() =>
            {
                return new User() { Name = "Mateus" };
            });
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
