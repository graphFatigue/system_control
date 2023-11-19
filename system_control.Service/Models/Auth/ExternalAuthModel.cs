using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Auth
{
    public class ExternalAuthModel
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
    }
}
