using BLL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Room
{
    public class CreateRoomModel : IMapTo<Core.Entity.Room>
    {
        public int Number {  get; set; }
        public int Floor { get; set; }
        public string OrganizationName { get; set; }
        public string DepartmentAddress { get; set; }
    }
}
