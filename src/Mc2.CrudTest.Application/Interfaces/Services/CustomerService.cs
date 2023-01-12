using Mc2.CrudTest.Application.DTOs.Customers;

namespace Mc2.CrudTest.Application.Interfaces.Services
{
    public interface CustomerService : IService
    {
        Task<int> Register(RegisterCustomerDto dto);
        Task<GetCustomerDto> Get(int id);
    }
}