using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazorProject.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateDepartment(Department department)
        {
            if (department == null) return false;
            _context.Departments.Add(department);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null) return false;
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return true;
        }

        public Department GetDepartmentById(int id)
        {
            var department = _context.Departments.Find(id);
            return department;
        }

        public IEnumerable<Department> GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }

        public bool UpdateDepartment(Department department)
        {
            if (department == null) return false;
            _context.Departments.Update(department);
            _context.SaveChanges();
            return true;
        }
    }
}
