using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Models
{
    public enum Priority { Low, Medium, High }
    public enum TaskStatuses { Backlog, Development, Testing, Completed }
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public TaskStatuses TaskStatuses { get; set; }  
    }
}
