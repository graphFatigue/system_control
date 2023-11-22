using Core.Entity;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Sieve.Configuratons
{
    public class VisitSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Visit>(x => x.DateTime)
                .CanFilter()
                .CanSort();

            mapper.Property<Visit>(x => x.Purpose)
                .CanFilter()
                .CanSort();
        }
    }
}
