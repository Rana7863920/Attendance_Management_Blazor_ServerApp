namespace BlazorProject.Models
{
    public class AttendanceStatus
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public int PunchedInUsers { get; set; } = 0;
    }
}
