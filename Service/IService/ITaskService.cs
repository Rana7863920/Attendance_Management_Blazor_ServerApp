using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface ITaskService
    {
        public List<Models.Task> GetTasks();
        public bool CreateTask(Models.Task task);
        public Models.Task GetTaskById(int id);
        public bool UpdateTask(Models.Task task);
        public bool DeleteTask(int id);
    }
}
