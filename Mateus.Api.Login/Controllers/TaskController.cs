using Login.Facades.TaskFacade.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mateus.Api.Login.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaskController:ControllerBase
    {

        private readonly ITaskFacade _taskFacade;

        public TaskController(ITaskFacade taskFacade)
        {
            _taskFacade = taskFacade;
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetAllTasks()
        {
            var userId = HttpContext.User.Claims.Where(c => c.Type.Equals(ClaimTypes.UserData)).FirstOrDefault().Value;



            return Ok(_taskFacade.GetTasks(userId)); 
        }

        [HttpPost("create")]
        [Authorize]
        public IActionResult CreateTasks(string taskTitle)
        {
            var userId = HttpContext.User.Claims.Where(c => c.Type.Equals(ClaimTypes.UserData)).FirstOrDefault().Value;

            var result = _taskFacade.CreateTask(taskTitle, userId);
            return result ? Ok("Task created successfully") : BadRequest("An error occurred while trying to create a Task");
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult UpdateTaks(string taskId)
        {
            var result = _taskFacade.UpdateTask(taskId);
            return result ? Ok("Updated successfully") : NotFound("Task not found in database");
         
        }

        [HttpPost("delete")]
        [Authorize]
        public IActionResult DeleteTask(string taskId)
        {
            var result = _taskFacade.DeleteTaks(taskId);

            return result ? Ok("Deleted successfully") : NotFound("Task not found in database");

        }



    }
}
