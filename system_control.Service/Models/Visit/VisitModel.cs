using AutoMapper;
using BLL.Mappings;
using BLL.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Visit
{
    public class VisitModel : IMapFrom<Core.Entity.Visit>
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Purpose { get; set; }
        public string? ClientFirstName { get; set; }
        public string? ClientLastName { get; set; }
        public string? StaffFirstName { get; set; }
        public string? StaffLastName { get; set; }
        public int RoomNumber { get; set; }
        public string OrganizationName { get; set; }
        public string DepartmentAddress { get; set; }
        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Core.Entity.Visit, VisitModel>()
                .ForMember(dest => dest.DateTime, src => src.MapFrom(opt => opt.DateTime))
                .ForMember(dest => dest.Purpose, src => src.MapFrom(opt => opt.Purpose))
                .ForMember(dest => dest.RoomNumber, src => src.MapFrom(opt => opt.Room.Number))
                .ForMember(dest => dest.OrganizationName, src => src.MapFrom(opt => opt.Room.Department.Organization.Name))
                .ForMember(dest => dest.DepartmentAddress, src => src.MapFrom(opt => opt.Room.Department.Address))
                .ForMember(dest => dest.ClientFirstName, src => src.MapFrom(opt => opt.Client.User.FirstName))
                .ForMember(dest => dest.ClientLastName, src => src.MapFrom(opt => opt.Client.User.LastName))
                .ForMember(dest => dest.StaffFirstName, src => src.MapFrom(opt => opt.Staff.User.FirstName))
                .ForMember(dest => dest.StaffLastName, src => src.MapFrom(opt => opt.Staff.User.LastName));
        }
    }
}
