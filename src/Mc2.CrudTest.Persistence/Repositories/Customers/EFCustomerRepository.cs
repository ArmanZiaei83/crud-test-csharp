using Mc2.CrudTest.Application.Interfaces.Repositories;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence.Repositories.Customers
{
    public class EFCustomerRepository : CustomerRepository
    {
        private readonly DbSet<Customer> _customers;

        public EFCustomerRepository(EFDataContext dataContext)
        {
            _customers = dataContext.Customers;
        }
    }
}