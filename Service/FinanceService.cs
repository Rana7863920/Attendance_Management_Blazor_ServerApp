using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;

namespace BlazorProject.Service
{
    public class FinanceService : IFinanceService
    {
        private readonly ApplicationDbContext _context;
        public FinanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Finance GetUserFinance(string userId)
        {
            var finance = _context.Finances.FirstOrDefault(f => f.ApplicationUserId == userId);
            return finance;
        }
    }
}
