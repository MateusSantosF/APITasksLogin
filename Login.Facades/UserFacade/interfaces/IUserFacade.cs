using Login.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Facades.UserFacade.interfaces
{
    public interface IUserFacade
    {
        
        public Task<User> GetUserAsync(string email, string password);

        public Task<bool> SignUpUserAsync(string email, string password, string name);


        public List<User> GetAllUsers();

    }
}
