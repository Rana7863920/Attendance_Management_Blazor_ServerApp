using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;

namespace BlazorProject.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly ApplicationDbContext _context;
        public SalaryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool SalaryCredit(MonthlySalary monthlySalary)
        {
            if (monthlySalary == null) return false;
            _context.MonthlySalaries.Add(monthlySalary);
            _context.SaveChanges();
            return true;
        }

        public MonthlySalary GetMonthlySalary(string userId)
        {
            if (userId == null) return null;
            var monthlySalary = _context.MonthlySalaries.FirstOrDefault(m => m.ApplicationUserId == userId);
            return monthlySalary;
        }
    }
}
