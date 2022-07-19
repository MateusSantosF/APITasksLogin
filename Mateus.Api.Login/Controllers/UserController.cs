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
        public IActionResult GetUser([FromQuery] string email, string password)
        {
            var result = _userFacade.GetUser(email, password);

            if (result is null) return NotFound();

            return Ok(result);

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
