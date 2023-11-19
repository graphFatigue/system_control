using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual ICollection<Visit>? Visits { get; set; }
        public virtual ICollection<UserRoom>? UserRooms { get; set; }
    }
}
