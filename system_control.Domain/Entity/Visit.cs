using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Purpose { get; set; }
        public int RoomId { get; set; }
        public virtual Room? Room { get; set; }

        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }

        public int StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
    }
}
