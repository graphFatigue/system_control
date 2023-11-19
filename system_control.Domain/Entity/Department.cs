using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string? Address { get; set; }

        public int OrganizationId { get; set; }
        public virtual Organization? Organization { get; set; }

        public virtual ICollection<Room>? Rooms { get; set; }
        public virtual ICollection<Staff>? Staff { get; set; }
        public virtual ICollection<ClientAccess>? ClientAccesses { get; set; }
        public virtual ICollection<ClientStaffAccess>? ClientStaffAccesses { get; set; }
        public virtual ICollection<StaffAccess>? StaffAccesses { get; set; }
    }
}
