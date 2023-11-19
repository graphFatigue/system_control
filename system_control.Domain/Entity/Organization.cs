using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Organization
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TypeOrganization TypeOrganization { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<Department>? Departments { get; set; }
    }
}
