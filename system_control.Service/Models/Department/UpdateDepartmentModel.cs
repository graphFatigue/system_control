using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Department
{
    public class UpdateDepartmentModel
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? OrganizationName { get; set; }
    }
}
