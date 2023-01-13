using Mc2.CrudTest.Application.DTOs.Customers;
using Mc2.CrudTest.Application.Interfaces.Repositories;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence.Repositories.Customers;

public class EFCustomerRepository : CustomerRepository
{
    private readonly DbSet<Customer> _customers;

    public EFCustomerRepository(EFDataContext dataContext)
    {
        _customers = dataContext.Customers;
    }

    public void Add(Customer customer)
    {
        _customers.Add(customer);
    }

    public Task<GetCustomerDto> Get(int id)
    {
        return _customers.Where(_ => _.Id == id)
            .Select(_ => new GetCustomerDto
            {
                Id = _.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                PhoneNumber = _.PhoneNumber,
                DateOfBirth = _.DateOfBirth,
                Email = _.Email,
                BankAccountNumber = _.BankAccountNumber
            }).FirstOrDefaultAsync();
    }

    public async Task<Customer> Find(int id)
    {
        return await _customers.FindAsync(id);
    }

    public async Task<bool> Exists(int id)
    {
        return await _customers.AnyAsync(_ => _.Id == id);
    }

    public void Delete(Customer customer)
    {
        _customers.Remove(customer);
    }
}