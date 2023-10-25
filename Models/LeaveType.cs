using System.ComponentModel.DataAnnotations;

namespace BlazorProject.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name cannot be empty")]
        public string Name { get; set; }
    }
}
