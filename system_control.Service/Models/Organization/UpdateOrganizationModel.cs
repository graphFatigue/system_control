using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Organization
{
    public class UpdateOrganizationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeOrganization { get; set; }
        public string Country { get; set; }
    }
}
