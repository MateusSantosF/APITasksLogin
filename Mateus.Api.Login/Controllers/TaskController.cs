using Login.Facades.TaskFacade.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllTasks(string userId)
        {
            return Ok(_taskFacade.GetTasks(userId)); 
        }

        [HttpPost("create")]

        public IActionResult CreateTasks(string taskTitle, string userId)
        {
            var result = _taskFacade.CreateTask(taskTitle, userId);

            return result ? Ok("Task created successfully") : BadRequest("An error occurred while trying to create a Task");
        }

        [HttpPost("update")]
        public IActionResult UpdateTaks(string taskId)
        {
            var result = _taskFacade.UpdateTask(taskId);

            return result ? Ok("Updated successfully") : NotFound("Task not found in database");
         
        }

        [HttpPost("delete")]
        public IActionResult DeleteTask(string taskId)
        {
            var result = _taskFacade.DeleteTaks(taskId);

            return result ? Ok("Deleted successfully") : NotFound("Task not found in database");

        }



    }
}
