using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class ClientStaffAccess
    {
        public int RelationId { get; set; }

        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }

        public int StaffId { get; set; }
        public virtual Staff? Staff { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
