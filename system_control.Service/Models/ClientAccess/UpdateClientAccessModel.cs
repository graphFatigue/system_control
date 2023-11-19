using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ClientAccess
{
    public class UpdateClientAccessModel
    {
        public int RelationId { get; set; }

        public string FirstClientFirstName { get; set; }
        public string FirstClientLastName { get; set; }

        public string SecondClientFirstName { get; set; }
        public string SecondClientLastName { get; set; }

        public string DepartmentAddress { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
