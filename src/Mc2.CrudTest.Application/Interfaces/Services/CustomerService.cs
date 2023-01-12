using Mc2.CrudTest.Application.DTOs.Customers;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Application.Interfaces.Services
{
    public interface CustomerService : IService
    {
        Task<int> Register(RegisterCustomerDto dto);
        Task<GetCustomerDto> Get(int id);
        Task Update(int id, UpdateCustomerDto dto);
        Task Delete(int id);
    }
}