using Microsoft.AspNetCore.Mvc;

namespace Mateus.Api.Login.Controllers
{
    public class TaskController:ControllerBase
    {


        public TaskController()
        {

        }


        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok("sd");
        }



    }
}
