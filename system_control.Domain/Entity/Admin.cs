using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Admin
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
