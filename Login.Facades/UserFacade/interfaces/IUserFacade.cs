using Login.Models;

namespace Login.Facades.UserFacade.interfaces
{
    public interface IUserFacade
    {
        
        public User? GetUser(string email, string password);

        public Task<bool> SignUpUserAsync(string email, string password, string name);

        public List<User> GetAllUsers();

    }
}
