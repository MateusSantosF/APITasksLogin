using Login.Facades.UserFacade;
using Login.Facades.UserFacade.interfaces;
using Login.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Mateus.Api.Login.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserFacade _userFacade;
        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }


        [HttpGet]
        public async Task<IActionResult> GetUserAsync([FromQuery] User user)
        {
            return Ok(await _userFacade.GetUserAsync(user.Email, user.Password));
        }

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userFacade.GetAllUsers());
        }


        [HttpPost]
        public async Task<IActionResult> SignUpUserAsync(string email, string password, string name)
        {
            return Ok(await _userFacade.SignUpUserAsync(email, password, name));
        }
        
    }
}
