using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Visit
{
    public class UpdateVisitModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Purpose { get; set; }
        public string? ClientFirstName { get; set; }
        public string? ClientLastName { get; set; }
        public string? StaffFirstName { get; set; }
        public string? StaffLastName { get; set; }
        public int RoomNumber { get; set; }
        public string OrganizationName { get; set; }
        public string DepartmentAddress { get; set; }
    }
}
