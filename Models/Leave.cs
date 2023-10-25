using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Models
{
    public class Leave
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime EndDate { get; set; } = DateTime.Now;
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        [EmailAddress]
        public string To { get; set; }
        [Required]
        [EmailAddress]
        public string CC { get; set; }
        public string Status { get; set; }
        [Required]
        public string File { get; set; }
        public string FileExtension { get; set; }
        public string ApplicationUserId { get; set; }
        public int LeaveTypeId { get; set; }
        [ForeignKey("LeaveTypeId, ApplicationUserId")]
        public virtual LeaveBalance LeaveBalance { get; set; }
    }
}
