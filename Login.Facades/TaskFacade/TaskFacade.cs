using Login.Facades.TaskFacade.interfaces;
using Login.Models;
using Login.Services.TaskService.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool CreateTask(string taskTitle, string userId)
        {

            var newTask = new Models.Task() { Id = Guid.NewGuid().ToString(), Title = taskTitle, HasChecked = false, UserId = userId };

            return _taskService.CreateTask(newTask);
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
