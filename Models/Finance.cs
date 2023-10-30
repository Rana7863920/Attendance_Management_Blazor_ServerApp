using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Models
{
    public class Finance
    {
        public int Id { get; set; }
        public int Package { get; set; }
        public bool PF { get; set; }
        public int Salary { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
