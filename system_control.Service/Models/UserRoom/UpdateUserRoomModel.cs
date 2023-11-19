using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.UserRoom
{
    public class UpdateUserRoomModel
    {
        public int RelationId { get; set; }

        public string User { get; set; }

        public int RoomNumber { get; set; }

        public string DepartmentAddress { get; set; }

        public AccessLevel? AccessLevel { get; set; }
    }
}
