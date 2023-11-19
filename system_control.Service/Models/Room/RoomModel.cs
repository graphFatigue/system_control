using AutoMapper;
using BLL.Mappings;
using BLL.Models.Department;

namespace BLL.Models.Room
{
    public class RoomModel : IMapFrom<Core.Entity.Room>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public string OrganizationName { get; set; }
        public string DepartmentAddress { get; set; }
        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Core.Entity.Room, RoomModel>()
                .ForMember(dest => dest.Number, src => src.MapFrom(opt => opt.Number))
                .ForMember(dest => dest.Floor, src => src.MapFrom(opt => opt.Floor))
                .ForMember(dest => dest.OrganizationName, src => src.MapFrom(opt => opt.Department.Organization.Name))
                .ForMember(dest => dest.DepartmentAddress, src => src.MapFrom(opt => opt.Department.Address));
        }
    }
}
