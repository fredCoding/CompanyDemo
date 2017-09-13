using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyDemo.Models
{
    public class ProjectManager
    {
        public int ProjectManagerId { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Workplace { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
