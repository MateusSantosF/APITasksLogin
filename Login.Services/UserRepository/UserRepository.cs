using Login.Models.User;
using Login.Services.Context;
using Login.Services.UserRepository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Services.UserRepository
{
    public class UserRepository:IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public List<User> GetAllUsers()
        {
            return _userContext.Users.ToList();
        }

        public async Task<bool> InsertUser(User user)
        {
            await _userContext.AddAsync(user);
            return await _userContext.SaveChangesAsync() > 0;
        }
    }
}
