using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Staff
    {
        public int Id { get; set; }
        public string? Position { get; set; }
        public DateTime DateOfEmployment { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        //public int OrganizationId { get; set; }
        //public virtual Organization? Organization { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Visit>? Visits { get; set; }
        public virtual ICollection<StaffAccess>? StaffAccesses { get; set; }
        public virtual ICollection<ClientStaffAccess>? ClientStaffAccesses { get; set; }
    }
}
