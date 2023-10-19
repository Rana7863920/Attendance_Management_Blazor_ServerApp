using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface ILeaveService
    {
        public bool ApplyLeave(Leave leave);
        public IEnumerable<Leave> GetLeaves();
        public bool UpdateLeave(Leave leave);
        public bool LeaveApproved(Leave leave);
        public IEnumerable<Leave> GetUserPendingLeaves();
        public IEnumerable<Leave> GetUserLeaves();
    }
}
