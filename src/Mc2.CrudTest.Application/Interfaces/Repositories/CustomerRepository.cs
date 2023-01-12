using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Application.Interfaces.Repositories
{
    public interface CustomerRepository : IRepository
    {
        void Add(Customer customer);
        Task<GetCustomerDto> Get(int id);
    }
}