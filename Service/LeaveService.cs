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
            int days = 0;
            TimeSpan timeSpanDays = leave.EndDate - leave.StartDate;
            if (timeSpanDays.Days == 0)
                days = 1;
            else if (timeSpanDays.Days == 1)
                days = timeSpanDays.Days + 1;
            else
                days = timeSpanDays.Days + 2;
            if (days > leaveBalance.Balance) return false;
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

        public IEnumerable<Leave> GetUserLeaves()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var leaves = _context.Leaves.Include(l => l.LeaveBalance).ToList().Where(l => l.ApplicationUserId == userId);
            foreach (var leave in leaves)
            {
                leave.LeaveBalance.ApplicationUser = _context.ApplicationUsers.Find(leave.ApplicationUserId);
                leave.LeaveBalance.LeaveType = _context.LeaveTypes.Find(leave.LeaveTypeId);
            }
            return leaves;
        }

        public IEnumerable<Leave> GetUserPendingLeaves()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var leaves = _context.Leaves.Include(l => l.LeaveBalance).ToList().Where(l => l.Status == "Pending" && l.ApplicationUserId == userId);
            foreach (var leave in leaves)
            {
                leave.LeaveBalance.ApplicationUser = _context.ApplicationUsers.Find(leave.ApplicationUserId);
                leave.LeaveBalance.LeaveType = _context.LeaveTypes.Find(leave.LeaveTypeId);
            }
            return leaves;
        }

        public bool LeaveApproved(Leave leave)
        {
            int days = 0;
            var leaveBalance = _context.LeaveBalances.FirstOrDefault(lb => lb.ApplicationUserId == leave.ApplicationUserId && lb.LeaveTypeId == leave.LeaveTypeId);
            if (leaveBalance == null) return false;
            TimeSpan timeSpanDays = leave.EndDate - leave.StartDate;
            if (leave.StartDate.ToShortDateString() == leave.EndDate.ToShortDateString())
                days = 1;
            else if (timeSpanDays.Days == 1)
                days = 2;
            else
            {
                days = timeSpanDays.Days + 2;
            }
            leaveBalance.Used += days;
            leaveBalance.Balance = leaveBalance.Granted - leaveBalance.Used;
            leave.Status = "Approved";
            _context.LeaveBalances.Update(leaveBalance);
            _context.Leaves.Update(leave);
            _context.SaveChanges();
            return true;
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
