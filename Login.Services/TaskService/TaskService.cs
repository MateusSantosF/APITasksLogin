using Login.Models;
using Login.Services.Context;
using Login.Services.TaskService.interfaces;

namespace Login.Services.TaskService
{
    public class TaskService : ITaskService
    {

        private readonly UserContext _userContext;

        public TaskService(UserContext userContext )
        {
            _userContext = userContext;
        }

        public List<Models.Task> GetTasks(string userId)
        {
            return _userContext.Tasks.Where( t => t.UserId.Equals(userId) ).ToList();
        }

        public bool CreateTask(Models.Task task)
        {
            _userContext.Tasks.Add(task);

            return _userContext.SaveChanges() > 0 ;
        }

        public bool UpdateTask(string taskId)
        {
            var task = _userContext.Tasks.FirstOrDefault(t => t.Id.Equals(taskId));

            if (task is null) return false;

            task.HasChecked = !task.HasChecked;
            _userContext.Tasks.Update(task);

            return _userContext.SaveChanges() > 0;
        }

        public bool DeleteTask(string taskId)
        {
            var task = _userContext.Tasks.FirstOrDefault(t => t.Id.Equals(taskId));

            if (task is null) return false;

            _userContext.Tasks.Remove(task);

            return _userContext.SaveChanges() > 0;

        }
    }
}
