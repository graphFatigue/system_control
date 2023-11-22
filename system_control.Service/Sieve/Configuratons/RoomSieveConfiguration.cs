using Core.Entity;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Sieve.Configuratons
{
    public class RoomSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Room>(x => x.Floor)
                .CanFilter()
                .CanSort();

            mapper.Property<Room>(x => x.Number)
                .CanFilter()
                .CanSort();
        }
    }
}
