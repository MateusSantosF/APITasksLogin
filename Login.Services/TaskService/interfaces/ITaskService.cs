using Login.Models;

namespace Login.Services.TaskService.interfaces
{
    public interface ITaskService
    {

        List<Models.Task> GetTasks(string userId);

        bool CreateTask(Models.Task task);

        bool UpdateTask(string taskId);

        bool DeleteTask(string taskId);





    }
}
