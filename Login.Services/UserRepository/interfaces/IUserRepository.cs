using Login.Models.User;

namespace Login.Services.UserRepository.interfaces
{
    public interface IUserRepository
    {

        List<User> GetAllUsers();

        Task<bool> InsertUser(User user);
    }
}
