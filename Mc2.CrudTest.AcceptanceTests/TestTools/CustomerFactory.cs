using System;
using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Persistence.Contexts;
using Mc2.CrudTest.Persistence.Repositories.Customers;
using Mc2.CrudTest.Persistence.UnitOfWork;

namespace Mc2.CrudTest.AcceptanceTests.TestTools
{
    public static class CustomerFactory
    {
        public static CustomerAppService CreateService(
            EFDataContext dataContext)
        {
            EFCustomerRepository repository =
                new EFCustomerRepository(dataContext);
            EFUnitOfWork unitOfWork = new EFUnitOfWork(dataContext);
            return new CustomerAppService(unitOfWork, repository);
        }

        public static Customer Create()
        {
            return new Customer
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                DateOfBirth = new DateTime(),
                PhoneNumber = "dummy-phone-number",
                Email = "dummy-email",
                BankAccountNumber = "123"
            };
        }
    }
}