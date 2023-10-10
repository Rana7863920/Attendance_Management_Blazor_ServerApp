using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorProject.Service
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LeaveBalanceService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<LeaveBalance> GetLeaveManagementList()
        {
            var leaveBalance = _context.LeaveBalances.Include(lb => lb.ApplicationUser).Include(lb => lb.LeaveType).ToList();
            return leaveBalance;
        }

        public bool CreateLeaveManagement(LeaveBalance leaveBalance)
        {
            if (leaveBalance == null) return false;
            _context.LeaveBalances.Add(leaveBalance);
            _context.SaveChanges();
            return true;
        }

        public LeaveBalance GetLeaveManagementById(string applicationUserId, int leaveTypeId)
        {
            var leaveManagement = _context.LeaveBalances.
                                    FirstOrDefault(lb => lb.ApplicationUserId == applicationUserId && lb.LeaveTypeId == leaveTypeId);
            return leaveManagement;
        }

        public bool UpdateLeaveManagement(LeaveBalance newLeaveBalance)
        {
            if (newLeaveBalance == null) return false;
            _context.LeaveBalances.Update(newLeaveBalance);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteLeaveManagement(string applicationUserId, int leaveTypeId)
        {
            var leaveBalance = _context.LeaveBalances.
                                FirstOrDefault(lb => lb.ApplicationUserId == applicationUserId && lb.LeaveTypeId == leaveTypeId);
            if(leaveBalance == null) return false;
            _context.LeaveBalances.Remove(leaveBalance);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<LeaveBalance> GetLeaveBalanceOfUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var leaveBalance = _context.LeaveBalances.Include(lb => lb.ApplicationUser).Include(lb => lb.LeaveType).
                                ToList().Where(lb => lb.ApplicationUserId == userId);
            return leaveBalance;
        }
    }
}
