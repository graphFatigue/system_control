using BLL.Mappings;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.User
{
    public class UserModel : IMapFrom<Core.Entity.User>
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public Role Role { get; set; }
    }
}
