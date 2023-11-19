using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class ClientAccess
    {
        public int RelationId { get; set; }

        public int FirstClientId { get; set; }
        public virtual Client? FirstClient { get; set; }

        public int SecondClientId { get; set; }
        public virtual Client? SecondClient { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
