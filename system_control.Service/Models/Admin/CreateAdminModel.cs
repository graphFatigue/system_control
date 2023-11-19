using BLL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Admin
{
    public class CreateAdminModel : IMapTo<Core.Entity.Admin>
    {
        public string? User { get; set; }
        public string? OrganizationName { get; set; }
        public string? DepartmentAddress { get; set; }
    }
}
