namespace BlazorProject.Models
{
    public class LeaveBalance
    {
        public int Granted { get; set; }
        public int Used { get; set; }
        public int Balance { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}
