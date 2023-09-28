using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;

namespace BlazorProject.Service
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var projects = _context.Projects.ToList();
            return projects;
        }

        public Project GetProjectById(int id)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == id);
            return project;
        }
    }
}
