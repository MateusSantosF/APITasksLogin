namespace Login.Facades.TaskFacade.interfaces
{
    public interface ITaskFacade
    {
        List<Models.Task> GetTasks(string userId);

        bool CreateTask(string taskTitle, string userId);

        bool UpdateTask(string taskId);

        bool DeleteTaks(string taskId);
    }
}
