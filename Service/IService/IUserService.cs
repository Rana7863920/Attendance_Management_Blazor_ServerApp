using BlazorProject.Models;

namespace BlazorProject.Service.IService
{
    public interface IUserService
    {
        public string GetUserName();
        public UserAttendance GetUser();
        public bool GetAutoTimeOut();
        public UserAttendance PunchIn();
        public void PunchOut();
        public void GetDuration();
        public IEnumerable<UserAttendance> GetAttendances();
        public IEnumerable<ApplicationUser> GetAllUsers();
        public ApplicationUser GetUserById(string id);
        public bool UpdateUser(ApplicationUser user);
        public ApplicationUser GetApplicationUser();
    }
}
