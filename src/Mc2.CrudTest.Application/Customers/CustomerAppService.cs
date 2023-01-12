using Mc2.CrudTest.Application.DTOs.Customers;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Application.Interfaces.Repositories;
using Mc2.CrudTest.Application.Interfaces.Services;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure.Shared.Validations;

namespace Mc2.CrudTest.Application.Customers
{
    public class CustomerAppService : CustomerService
    {
        private readonly CustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerAppService(
            IUnitOfWork unitOfWork,
            CustomerRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<int> Register(RegisterCustomerDto dto)
        {
            var customer = new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                BankAccountNumber = dto.BankAccountNumber
            };

            _repository.Add(customer);
            await _unitOfWork.Complete();

            return customer.Id;
        }
    }
}