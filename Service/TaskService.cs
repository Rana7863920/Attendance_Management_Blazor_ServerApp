using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;

namespace BlazorProject.Service
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Models.Task> GetTasks()
        {
            var tasks = _context.Tasks.ToList();
            return tasks;
        }

        public bool CreateTask(Models.Task task)
        {
            if(task == null) return false;
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == task.UserId);
            var project = _context.Projects.FirstOrDefault(p => p.Id == task.ProjectId);
            task.ApplicationUser = user;
            task.Project = project;
            _context.Tasks.Add(task);
            _context.SaveChanges(); 
            return true;
        }

        public Models.Task GetTaskById(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            return task;
        }
    }
}
