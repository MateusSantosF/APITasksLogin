using Login.Facades.UserFacade.interfaces;
using Login.Services.TokenService.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mateus.Api.Login.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserFacade _userFacade;
        private readonly ITokenService _tokenService;

        public UserController(IUserFacade userFacade, ITokenService tokenService)
        {
            _userFacade = userFacade;
            _tokenService = tokenService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<dynamic> GetUser([FromQuery] string email, string password)
        {
            var result = _userFacade.GetUser(email, password);
            if (result is null) return NotFound();

            var token = _tokenService.GenerateToken(result);
            result.Password = "";

            return new { user = result, token = token };

        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            return Ok(_userFacade.GetAllUsers());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpUserAsync(string email, string password, string name)
        {
            var result = await _userFacade.SignUpUserAsync(email, password, name);

            return result ? Ok("Registered successfully") : BadRequest("There is already a user with this data");
        }
        
    }
}
