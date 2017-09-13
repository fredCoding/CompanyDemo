using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyDemo.Models
{
    public class Director
    {
        public int DirectorId { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Workplace { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<ProjectManager> Managers { get; set; }
    }
}
