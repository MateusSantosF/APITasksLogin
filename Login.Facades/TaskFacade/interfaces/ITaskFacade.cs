namespace Login.Facades.TaskFacade.interfaces
{
    public interface ITaskFacade
    {
        List<Models.Task> GetTasks(string userId);

        Models.Task CreateTask(string taskTitle, string userId);

        bool UpdateTask(string taskId);

        bool DeleteTaks(string taskId);
    }
}
