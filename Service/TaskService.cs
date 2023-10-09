using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;
using Microsoft.EntityFrameworkCore;

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
            var tasks = _context.Tasks.Include(t => t.ApplicationUser).Include(t => t.Project).ToList();
            return tasks;
        }

        public bool CreateTask(Models.Task task)
        {
            if(task == null) return false;
            _context.Tasks.Add(task);
            _context.SaveChanges(); 
            return true;
        }

        public Models.Task GetTaskById(int id)
        {
            var task = _context.Tasks.Include(t => t.Project).Include(t => t.ApplicationUser).FirstOrDefault(t => t.Id == id);
            return task;
        }

        public bool UpdateTask(Models.Task task)
        {
            if (task == null) return false;
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return true;
        }
    }
}
