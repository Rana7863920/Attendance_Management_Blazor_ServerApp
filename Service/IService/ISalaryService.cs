using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface ISalaryService
    {
        public bool SalaryCredit(MonthlySalary monthlySalary);
        public MonthlySalary GetMonthlySalary(string userId);
    }
}
