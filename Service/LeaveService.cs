using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorProject.Service
{
    public class LeaveService:ILeaveService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LeaveService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool ApplyLeave(Leave leave)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var leaveBalance = _context.LeaveBalances.
                                FirstOrDefault(lb => lb.ApplicationUserId == userId && lb.LeaveTypeId == leave.LeaveTypeId);  
            TimeSpan days = leave.EndDate - leave.StartDate;
            if (days.Days + 2 > leaveBalance.Granted) return false;
            if (leave == null) return false;
            leave.ApplicationUserId = userId;
            leave.Status = "Pending";
            _context.Leaves.Add(leave);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Leave> GetLeaves()
        {
            var leaves = _context.Leaves.Include(l => l.LeaveBalance).ToList().Where(l => l.Status == "Pending");
            foreach (var leave in leaves)
            {
                leave.LeaveBalance.ApplicationUser = _context.ApplicationUsers.Find(leave.ApplicationUserId);
                leave.LeaveBalance.LeaveType = _context.LeaveTypes.Find(leave.LeaveTypeId);
            }
            return leaves;
        }

        public bool UpdateLeave(Leave leave)
        {
            if (leave == null) return false;
            _context.Leaves.Update(leave);
            _context.SaveChanges();
            return true;
        }
    }
}
