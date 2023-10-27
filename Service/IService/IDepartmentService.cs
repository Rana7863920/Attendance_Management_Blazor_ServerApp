using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface IDepartmentService
    {
        public IEnumerable<Department> GetDepartments();
        public bool CreateDepartment(Department department);
        public bool UpdateDepartment(Department department);
        public bool DeleteDepartment(int id);
        public Department GetDepartmentById(int id);
    }
}
