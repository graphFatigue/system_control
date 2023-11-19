﻿using BLL.Mappings;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.StaffAccess
{
    public class CreateStaffAccessModel: IMapTo<Core.Entity.StaffAccess>
    {
        public string FirstStaffFirstName { get; set; }
        public string FirstStaffLastName { get; set; }

        public string SecondStaffFirstName { get; set; }
        public string SecondStaffLastName { get; set; }

        public string DepartmentAddress { get; set; }

        public AccessLevel AccessLevel { get; set; }
    }
}
