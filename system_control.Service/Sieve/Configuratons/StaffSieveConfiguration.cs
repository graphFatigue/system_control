using Core.Entity;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Sieve.Configuratons
{
    public class StaffSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Staff>(x => x.Position)
                .CanFilter()
                .CanSort();

            mapper.Property<Staff>(x => x.DateOfEmployment)
                .CanFilter()
                .CanSort();
        }
    }
}
