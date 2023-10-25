using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Models
{
    public enum Priority { Low, Medium, High }
    public enum TaskStatuses { Backlog, Development, Testing, Completed }
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [Required]
        public TaskStatuses TaskStatuses { get; set; }  
    }
}
