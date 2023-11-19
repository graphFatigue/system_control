using BLL.Mappings;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ClientAccess
{
    public class CreateClientAccessModel: IMapTo<Core.Entity.ClientAccess>
    {
        public string FirstClientFirstName { get; set; }
        public string FirstClientLastName { get; set; }

        public string SecondClientFirstName { get; set; }
        public string SecondClientLastName { get; set; }

        public string DepartmentAddress { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
