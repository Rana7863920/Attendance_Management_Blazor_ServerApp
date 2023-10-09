using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface ILeaveTypeService
    {
        public IEnumerable<LeaveType> GetLeaveTypes();
        public LeaveType GetLeaveTypeById(int id);
        public bool CreateLeaveType(LeaveType leaveType);
        public bool UpdateLeaveType(LeaveType leaveType);
        public bool DeleteLeaveType(int id);
    }
}
