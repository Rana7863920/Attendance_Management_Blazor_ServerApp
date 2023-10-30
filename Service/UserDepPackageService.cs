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

        public bool AddPackage(ApplicationUser applicationUser, string optForPF)
        {
            if (applicationUser == null) return false;
            if (optForPF == "Yes")
            {
                applicationUser.Finance.PF = true;
            }
            else
            {
                applicationUser.Finance.PF = false;
            }
            applicationUser.Finance.Salary = applicationUser.Finance.Package / 12;
            var finance = _context.Finances.FirstOrDefault(f => f.ApplicationUserId == applicationUser.Id);
            if(finance == null)
            {
                Finance userFinance = new Finance()
                {
                    Package = applicationUser.Finance.Package,
                    Salary = applicationUser.Finance.Salary,
                    PF = applicationUser.Finance.PF,
                    ApplicationUserId = applicationUser.Id
                };
                _context.Finances.Add(userFinance);
            }
            else
            {
                finance.Package = applicationUser.Finance.Package;
                finance.PF = applicationUser.Finance.PF;
                finance.Salary = applicationUser.Finance.Salary;
                _context.Finances.Update(finance);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
