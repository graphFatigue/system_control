using BLL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Client
{
    public class CreateClientModel : IMapTo<Core.Entity.Client>
    {
        public string? User { get; set; }
        //public string? Department { get; set; }
    }
}
