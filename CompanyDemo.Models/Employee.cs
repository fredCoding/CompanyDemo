using System.ComponentModel.DataAnnotations;

namespace CompanyDemo.Models
{
    public enum Position
    {
        Trainee,
        Junior,
        Intermediate,
        Senior
    }
    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        public Position Position { get; set; }

        public decimal Salary { get; set; }
        
        public string Workplace { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual Team Team { get; set; }
    }
}
