using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface IUserService
    {
        public string GetUserName();
        public UserAttendance PunchIn();
    }
}
