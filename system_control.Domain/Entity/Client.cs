using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Visit>? Visits { get; set; }
        public virtual ICollection<ClientAccess>? ClientAccesses { get; set; }
        //public virtual ICollection<ClientAccess>? SecondClientAccesses { get; set; }
        public virtual ICollection<ClientStaffAccess>? ClientStaffAccesses { get; set; }
    }
}
