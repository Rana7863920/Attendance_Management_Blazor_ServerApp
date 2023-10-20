using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;
using System.Collections.Generic;

namespace BlazorProject.Service
{
    public class AttendanceStatusService : IAttendanceStatusService
    {
        private readonly ApplicationDbContext _context;
        public AttendanceStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAttendanceStatus()
        {
            var todayStatus = _context.AttendanceStatuses.FirstOrDefault(a => a.CurrentDate.Date == DateTime.Now.Date);
            if(todayStatus == null)
            {
                Models.AttendanceStatus attendanceStatus = new Models.AttendanceStatus()
                {
                    CurrentDate = DateTime.Now,
                    PunchedInUsers = 1
                };
                _context.AttendanceStatuses.Add(attendanceStatus);
                _context.SaveChanges();
            }
            else
            {
                todayStatus.PunchedInUsers += 1;
                _context.AttendanceStatuses.Update(todayStatus);
                _context.SaveChanges();
            }
        }

        public IEnumerable<AttendanceStatus> GetAttendanceStatuses()
        {
            var attendanceStatuses = _context.AttendanceStatuses.ToList().OrderBy(a => a.CurrentDate);
            return attendanceStatuses;
        }

        public int GetTodayStatus()
        {
            var todayStatus = _context.AttendanceStatuses.FirstOrDefault(a => a.CurrentDate.Date == DateTime.Now.Date);
            if (todayStatus == null) 
                return 0;
            else
                return todayStatus.PunchedInUsers;
        }

        public int TotalUsers()
        {
            int totalUsers = _context.ApplicationUsers.ToList().Count();
            return totalUsers - 1;
        }
    }
}
