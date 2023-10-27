using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;

namespace BlazorProject.Service
{
    public class UserDepPackageService : IUserDepPackageService
    {
        private readonly ApplicationDbContext _context;
        public UserDepPackageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddDepPackage(ApplicationUser applicationUser, string optForPF)
        {
            if (applicationUser == null) return false;
            if(optForPF == "Yes")
            {
                applicationUser.Finance.PF = true;
            }
            else
            {
                applicationUser.Finance.PF = false;
            }
            applicationUser.Finance.Salary = applicationUser.Finance.Package / 12;
            var user = _context.ApplicationUsers.FirstOrDefault(a => a.Id == applicationUser.Id);
            user.Finance = applicationUser.Finance;
            user.DepartmentId = applicationUser.DepartmentId;
            var department = _context.Departments.FirstOrDefault(d => d.Id == applicationUser.DepartmentId);
            user.Department = department;
            _context.ApplicationUsers.Update(user);
            _context.SaveChanges();
            return true;
        }
    }
}
