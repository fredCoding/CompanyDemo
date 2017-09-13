using System.ComponentModel.DataAnnotations;

namespace CompanyDemo.Models
{
    public class TeamLead
    {
        public int TeamLeadId { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Workplace { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual Team Team { get; set; }
    }
}
