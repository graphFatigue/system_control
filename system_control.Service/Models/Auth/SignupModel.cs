using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using system_control.
using BLL.Mappings;
using Core.Enum;

namespace BLL.Models.Auth
{
    public class SignupModel : IMapTo<Core.Entity.User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void MapTo(Profile profile)
        {
            profile.CreateMap<SignupModel, Core.Entity.User>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(opt => opt.Email));
        }
    }
}
