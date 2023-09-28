using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface IProjectService
    {
        public IEnumerable<Project> GetAllProjects();
        public Project GetProjectById(int id);
    }
}
