using System.Runtime.InteropServices;
using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Persistence.Contexts;
using Mc2.CrudTest.Persistence.Repositories.Customers;
using Mc2.CrudTest.Persistence.UnitOfWork;

namespace Mc2.CrudTest.AcceptanceTests.TestTools
{
    public static class CustomerFactory
    {
        public static CustomerAppService CreateService(EFDataContext dataContext)
        {
            var repository = new EFCustomerRepository(dataContext);
            var unitOfWork = new EFUnitOfWork(dataContext);
            return new CustomerAppService(unitOfWork, repository);
        }
    }
}