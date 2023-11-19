using Core.Entity;
using Sieve.Services;

namespace BLL.Sieve.Configuratons
{
    public class OrganizationSieveConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Organization>(x => x.Name)
                .CanFilter()
                .CanSort();

            mapper.Property<Organization>(x => x.Country)
                .CanFilter()
                .CanSort();

            mapper.Property<Organization>(x => x.TypeOrganization)
                .CanFilter()
                .CanSort();
        }
    }
}
