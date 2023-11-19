using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class UserRoom
    {
        public int RelationId { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public int RoomId { get; set; }
        public virtual Room? Room { get; set; }

        public AccessLevel? AccessLevel { get; set; }
    }
}
