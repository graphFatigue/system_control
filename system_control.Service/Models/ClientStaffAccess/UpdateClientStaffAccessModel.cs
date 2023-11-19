using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ClientStaffAccess
{
    public class UpdateClientStaffAccessModel
    {
        public int RelationId { get; set; }

        public string? ClientFirstName { get; set; }
        public string? ClientLastName { get; set; }
        public string? StaffFirstName { get; set; }
        public string? StaffLastName { get; set; }
        public string DepartmentAddress { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
