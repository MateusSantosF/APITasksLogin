using Login.Facades.TaskFacade.interfaces;
using Login.Services.TaskService.interfaces;

namespace Login.Facades.TaskFacade
{
    public class TaskFacade : ITaskFacade
    {

        private readonly ITaskService _taskService;

        public TaskFacade(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public List<Models.Task> GetTasks(string userId)
        {
            return _taskService.GetTasks(userId);
        }

        public Models.Task? CreateTask(string taskTitle, string userId)
        {

            var newTask = new Models.Task() { Id = Guid.NewGuid().ToString(), Title = taskTitle, HasChecked = false, UserId = userId };
            
            var result = _taskService.CreateTask(newTask);

            return result ? newTask : null;
        }

        public bool UpdateTask(string taskId)
        {

            return _taskService.UpdateTask(taskId);
        }

        public bool DeleteTaks(string taskId)
        {
            return _taskService.DeleteTask(taskId);
        }
    }
}
