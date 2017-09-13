using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDemo.Models
{
    public class Team
    {
        [ForeignKey("TeamLead")]
        public int TeamId { get; set; }

        public string Description { get; set; }

        public virtual TeamLead TeamLead { get; set; }

        public virtual ProjectManager Manager { get; set; }

        public virtual ICollection<Employee> Members { get; set; }
    }
}
