using System.Collections.Generic;

namespace CompanyDemo.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public virtual ProjectManager Manager { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
