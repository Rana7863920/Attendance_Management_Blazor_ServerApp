using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string Contact { get; set; }
        public string Reason { get; set; }
        [EmailAddress]
        public string To { get; set; }
        [EmailAddress]
        public string CC { get; set; }
        public string Status { get; set; }
        public string File { get; set; }
        public string FileExtension { get; set; }
        public string ApplicationUserId { get; set; }
        public int LeaveTypeId { get; set; }
        [ForeignKey("LeaveTypeId, ApplicationUserId")]
        public virtual LeaveBalance LeaveBalance { get; set; }
    }
}
