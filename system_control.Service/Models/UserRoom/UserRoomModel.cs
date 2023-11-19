using BLL.Mappings;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.UserRoom
{
    public class UserRoomModel : IMapFrom<Core.Entity.UserRoom>
    {
        public int RelationId { get; set; }

        public string User { get; set; }

        public int RoomNumber { get; set; }

        public string DepartmentAddress { get; set; }

        public AccessLevel? AccessLevel { get; set; }
    }
}
