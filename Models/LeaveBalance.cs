using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Models
{
    public class LeaveBalance
    {
        [Required]
        public int Granted { get; set; }
        public int Used { get; set; }
        public int Balance { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        [ForeignKey("LeaveType")]
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}
