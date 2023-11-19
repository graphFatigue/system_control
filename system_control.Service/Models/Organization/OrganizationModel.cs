using AutoMapper;
using BLL.Mappings;
using BLL.Models.Department;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Organization
{
    public class OrganizationModel : IMapFrom<Core.Entity.Organization>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeOrganization { get; set; }
        public string Country { get; set; }
        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Core.Entity.Organization, OrganizationModel>()
                .ForMember(dest => dest.Name, src => src.MapFrom(opt => opt.Name))
                .ForMember(dest => dest.Description, src => src.MapFrom(opt => opt.Description))
                .ForMember(dest => dest.TypeOrganization, src => src.MapFrom(opt => Enum.GetName(opt.TypeOrganization)))
                .ForMember(dest => dest.Country, src => src.MapFrom(opt => Enum.GetName(opt.Country)));
        }
    }
}
