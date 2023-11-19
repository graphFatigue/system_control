using Core.Entity;
using Core.Enum;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers
{
    internal class OrganizationsDataInitializer
    {
        internal static void SeedData(ModelBuilder builder)
        {
            builder.Entity<Organization>().HasData
            (
                new Organization()
                {
                    Id = 1,
                    Name = "АТБ",
                    TypeOrganization = TypeOrganization.Shop,
                    Description = "найбільша українська мережа супермаркетів як за товарообігом, так і за числом крамниць",
                    Country = Country.UA
                },
                new Organization()
                {
                    Id = 2,
                    Name = "EVA",
                    TypeOrganization = TypeOrganization.Shop,
                    Description = "одна з найбільших торгових мереж, що займається офлайн- та онлайн-торгівлею товарами для краси та здоров'я",
                    Country = Country.UA
                },
                new Organization()
                {
                    Id = 3,
                    Name = "ZARA",
                    TypeOrganization = TypeOrganization.Shop,
                    Description = "флагманська торговельна мережа групи компаній Inditex Group, що належить іспанському магнату Амансіо Ортега",
                    Country = Country.ES
                });
        }
    }
}
