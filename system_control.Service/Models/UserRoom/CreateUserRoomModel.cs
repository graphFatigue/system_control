using BLL.Mappings;
using Core.Enum;

namespace BLL.Models.UserRoom
{
    public class CreateUserRoomModel : IMapTo<Core.Entity.UserRoom>
    {
        public string User {  get; set; }

        public int RoomNumber { get; set; }

        public string DepartmentAddress { get; set; }

        public AccessLevel? AccessLevel { get; set; }
    }
}
