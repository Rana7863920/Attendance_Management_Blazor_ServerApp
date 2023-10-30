using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace BlazorProject.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserName()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return "";
            }
            return user.Name;
        }

        public UserAttendance GetUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.UserAttendances.FirstOrDefault(u => u.CurrentDate.Date == DateTime.Now.Date && u.UserId == userId);
            return user;
        }

        public bool GetAutoTimeOut()
        {
            GetDuration();
            int timeOut = 0;
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.UserAttendances.FirstOrDefault(u => u.CurrentDate.Date == DateTime.Now.Date && u.UserId == userId);
            if (user != null)
            {
                timeOut = int.Parse(user.TimeOut.Hour.ToString());
                int duration = int.Parse(user.Duration.Hours.ToString());
                if (duration >= 10 && timeOut <= 0)
                {
                    user.TimeOut = DateTime.Now;
                    _context.UserAttendances.Update(user);
                    _context.SaveChanges();
                    return true;
                }
            }
            if (timeOut <= 0)
                return false;
            else
                return true;
        }

        public UserAttendance PunchIn()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var date = DateTime.Now;
            var time = DateTime.Now;
            UserAttendance user = new UserAttendance()
            {
                CurrentDate = date,
                TimeIn = time,
                UserId = userId,
                TimeOut = DateTime.MinValue
            };
            _context.UserAttendances.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void PunchOut()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var attendance = _context.UserAttendances.FirstOrDefault(u => u.CurrentDate.Date == DateTime.Now.Date && u.UserId == userId);
            attendance.TimeOut = DateTime.Now;
            attendance.Duration = attendance.TimeOut - attendance.TimeIn;
            _context.UserAttendances.Update(attendance);
            _context.SaveChanges();
        }

        public void GetDuration()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var attendance = _context.UserAttendances.FirstOrDefault(u => u.CurrentDate.Date == DateTime.Now.Date && u.UserId == userId);
            if(attendance != null)
            {
                int timeOut = int.Parse(attendance.TimeOut.Hour.ToString());
                if(timeOut <= 0)
                {
                    attendance.Duration = DateTime.Now - attendance.TimeIn;
                    _context.UserAttendances.Update(attendance);
                    _context.SaveChanges();
                }
            }
        }

        public IEnumerable<UserAttendance> GetAttendances()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userAttendances = _context.UserAttendances.ToList().Where(u => u.UserId == userId).OrderBy(u => u.CurrentDate);
            return userAttendances;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            var users = _context.ApplicationUsers.ToList().Where(a => a.Id != "f16aa2b8-d99c-4211-874c-46d8bd0e0a59");
            return users;
        }

        public ApplicationUser GetUserById(string id)
        {
            var user = _context.ApplicationUsers.Include(a => a.Department).FirstOrDefault(u => u.Id == id);
            return user;
        }

        public bool UpdateUser(ApplicationUser user)
        {
            if (user == null) return false;
            _context.ApplicationUsers.Update(user);
            _context.SaveChanges();
            return true;
        }

        public ApplicationUser GetApplicationUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationUser = _context.ApplicationUsers.Include(a => a.Department).FirstOrDefault(a => a.Id == userId);
            return applicationUser;
        }
    }
}
