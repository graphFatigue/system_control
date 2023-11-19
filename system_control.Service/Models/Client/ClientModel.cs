using AutoMapper;
using BLL.Mappings;
using Core.Enum;

namespace BLL.Models.Client
{
    public class ClientModel: IMapFrom<Core.Entity.Client>
    {
        public int Id { get; set; }
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        //public string? Patronymic { get; set; }
        //public DateTime BirthDate { get; set; }
        //public Sex Sex { get; set; }
        //public string? Department { get; set; }
        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Core.Entity.Client, ClientModel>();
                //.ForMember(dest => dest.Sex, src => src.MapFrom(opt => opt.User.Sex == Sex.M ? "Ч" : "Ж"))
                //.ForMember(dest => dest.FirstName, src => src.MapFrom(opt => opt.User.FirstName))
                //.ForMember(dest => dest.LastName, src => src.MapFrom(opt => opt.User.LastName))
                //.ForMember(dest => dest.Patronymic, src => src.MapFrom(opt => opt.User.Patronymic))
                //.ForMember(dest => dest.BirthDate, src => src.MapFrom(opt => opt.User.BirthDate));
                //.ForMember(dest => dest.Department, src => src.MapFrom(opt => opt.Department.Id));
        }
    }
}
