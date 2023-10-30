using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Models
{
    public class MonthlySalary
    {
        public int Id { get; set; }
        public DateTime Month { get; set; }
        public int Salary { get; set; }
        public int PfAmount { get; set; }
        public int Overtime { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
