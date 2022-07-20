using Login.Models;

namespace Login.Services.TokenService.interfaces
{
    public interface ITokenService
    {

        string GenerateToken(User user); 

    }
}
