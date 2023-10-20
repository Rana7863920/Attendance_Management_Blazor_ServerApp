using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface IAttendanceStatusService
    {
        public void AddAttendanceStatus();
        public int GetTodayStatus();
        public IEnumerable<AttendanceStatus> GetAttendanceStatuses();
        public int TotalUsers();
    }
}
