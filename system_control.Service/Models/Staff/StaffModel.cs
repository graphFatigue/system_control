﻿using AutoMapper;
using BLL.Mappings;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Staff
{
    public class StaffModel: IMapFrom<Core.Entity.Staff>
    {
        public int Id { get; set; }
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        //public string? Patronymic { get; set; }
        //public DateTime BirthDate { get; set; }
        //public Sex Sex { get; set; }
        public string? OrganizationName { get; set; }
        public string? DepartmentAddress { get; set; }
        public string? Position { get; set; }
        public DateTime DateOfEmployment { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Core.Entity.Staff, StaffModel>()
                .ForMember(dest => dest.OrganizationName, src => src.MapFrom(opt => opt.Department.Organization.Name))
                .ForMember(dest => dest.DepartmentAddress, src => src.MapFrom(opt => opt.Department.Address))
                //.ForMember(dest => dest.FirstName, src => src.MapFrom(opt => opt.User.FirstName))
                //.ForMember(dest => dest.LastName, src => src.MapFrom(opt => opt.User.LastName))
                //.ForMember(dest => dest.Patronymic, src => src.MapFrom(opt => opt.User.Patronymic))
                //.ForMember(dest => dest.Sex, src => src.MapFrom(opt => opt.User.Sex == Sex.M ? "Ч" : "Ж"))
                //.ForMember(dest => dest.BirthDate, src => src.MapFrom(opt => opt.User.BirthDate))
                .ForMember(dest => dest.DateOfEmployment, src => src.MapFrom(opt => opt.DateOfEmployment))
                .ForMember(dest => dest.Position, src => src.MapFrom(opt => opt.Position));
        }
    }
}
