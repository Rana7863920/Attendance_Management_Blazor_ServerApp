using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;
using Microsoft.AspNetCore.Mvc;
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
            if(user == null)
            {
                return "";
            }
            return user.Name;
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
                UserId = userId
            };
            _context.UserAttendances.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
