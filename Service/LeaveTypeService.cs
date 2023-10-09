using BlazorProject.Data;
using BlazorProject.Models;
using BlazorProject.Service.IService;

namespace BlazorProject.Service
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ApplicationDbContext _context;
        public LeaveTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateLeaveType(LeaveType leaveType)
        {
            _context.LeaveTypes.Add(leaveType);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteLeaveType(int id)
        {
            if(id == null) return false;
            var leaveType = _context.LeaveTypes.Find(id);
            if(leaveType == null) return false;
            _context.LeaveTypes.Remove(leaveType);
            _context.SaveChanges();
            return true;
        }

        public LeaveType GetLeaveTypeById(int id)
        {
            var leaveType = _context.LeaveTypes.FirstOrDefault(l => l.Id == id);
            return leaveType;
        }

        public IEnumerable<LeaveType> GetLeaveTypes()
        {
            var leaveTypesList = _context.LeaveTypes.ToList();
            return leaveTypesList;
        }

        public bool UpdateLeaveType(LeaveType leaveType)
        {
            _context.LeaveTypes.Update(leaveType);
            _context.SaveChanges();
            return true;
        }
    }
}
