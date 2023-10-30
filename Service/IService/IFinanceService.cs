using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface IFinanceService
    {
        public Finance GetUserFinance(string userId);
    }
}
