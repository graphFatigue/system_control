using AutoMapper;
using BLL.Mappings;
using BLL.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Department
{
    public class DepartmentModel: IMapFrom<Core.Entity.Department>
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? OrganizationName { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Core.Entity.Department, DepartmentModel>()
                .ForMember(dest => dest.OrganizationName, src => src.MapFrom(opt => opt.Organization.Name))
                .ForMember(dest => dest.Address, src => src.MapFrom(opt => opt.Address));
        }
    }
}
