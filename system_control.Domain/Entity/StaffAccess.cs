using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class StaffAccess
    {
        public int RelationId { get; set; }

        public int FirstStaffId { get; set; }
        public virtual Staff? FirstStaff { get; set; }

        public int SecondStaffId { get; set; }
        public virtual Staff? SecondStaff { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
