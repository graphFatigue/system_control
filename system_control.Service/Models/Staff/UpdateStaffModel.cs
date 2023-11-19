using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Staff
{
    public class UpdateStaffModel
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public string? OrganizationName { get; set; }
        public string? Position { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string? DepartmentAddress { get; set; }
    }
}
