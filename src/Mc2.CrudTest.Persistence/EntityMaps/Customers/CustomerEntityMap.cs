using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Persistence.EntityMaps.Customers
{
    public class StudentEntityMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> _)
        {
            _.ToTable("Customers");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id);
            _.Property(_ => _.Email);
            _.Property(_ => _.FirstName);
            _.Property(_ => _.LastName);
            _.Property(_ => _.PhoneNumber);
            _.Property(_ => _.BankAccountNumber);
            _.Property(_ => _.DateOfBirth);
        }
    }
}