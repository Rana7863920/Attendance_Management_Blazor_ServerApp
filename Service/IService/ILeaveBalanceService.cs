using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface ILeaveBalanceService
    {
        public IEnumerable<LeaveBalance> GetLeaveManagementList();
        public bool CreateLeaveManagement(LeaveBalance leaveBalance);
        public LeaveBalance GetLeaveManagementById(string applicationUserId, int leaveTypeId);
        public bool UpdateLeaveManagement(LeaveBalance newLeaveBalance);
        public bool DeleteLeaveManagement(string applicationUserId, int leaveTypeId);
        public IEnumerable<LeaveBalance> GetLeaveBalanceOfUser();
    }
}
