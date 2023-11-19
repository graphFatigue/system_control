using BLL.Mappings;

namespace BLL.Models.Visit
{
    public class CreateVisitModel : IMapTo<Core.Entity.Visit>
    {
        public DateTime DateTime { get; set; }
        public string? Purpose { get; set; }
        public string? ClientFirstName { get; set; }
        public string? ClientLastName { get; set; }
        public string? StaffFirstName { get; set; }
        public string? StaffLastName { get; set; }
        public int RoomNumber { get; set; }
        //public int RoomId { get; set; }
        public string OrganizationName { get; set; }
        //public int OrganizationId { get; set; }
        public string DepartmentAddress { get; set; }
        //public string DepartmentId { get; set; }
    }
}
