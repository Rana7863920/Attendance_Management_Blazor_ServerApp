using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Models
{
    public class UserAttendance
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public TimeSpan Duration { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
