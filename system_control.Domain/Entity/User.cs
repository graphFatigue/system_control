using Microsoft.AspNetCore.Identity;
using Core.Enum;

namespace Core.Entity
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<UserRoom>? UserRooms { get; set; }
    }
}
