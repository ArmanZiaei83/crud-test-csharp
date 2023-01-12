using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Mc2.CrudTest.AcceptanceTests.Infrastructures;
using Mc2.CrudTest.AcceptanceTests.TestTools;
using Mc2.CrudTest.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests : TestProvider
    {
        private readonly CustomerService _sut;

        public BddTddTests()
        {
            _sut = CustomerServiceFactory.CreateService(_dataContext);
        }

        [Fact]
        public async Task CreateCustomerValid_ReturnsSuccess()
        {
            var dto = new RegisterCustomerDtoBuilder()
                .Build();

            var userId = await _sut.Register(dto);

            var actualResult = _readDataContext.Customers.Single(
                _ => _.Id == userId);
            actualResult.FirstName.Should().Be(dto.FirstName);
            actualResult.LastName.Should().Be(dto.LastName);
            actualResult.DateOfBirth.Should().Be(dto.DateOfBirth);
            actualResult.PhoneNumber.Should().Be(dto.PhoneNumber);
            actualResult.Email.Should().Be(dto.Email);
            actualResult.BankAccountNumber.Should().Be(dto.BankAccountNumber);
        }

        [Fact]
        [Given("No customer is defined")]
        [When(
            "I add a customer with first name 'Arman', last name 'Ziaei', " +
            "phone number '09397136812', email 'arman@gmail.com', " +
            "bank account number '4037997432954623', and date of birth '2020-02-02'")]
        [Then("There must be a customer with first name 'arman', last name 'ziaei', " +
              "phone number '09397136812', email 'arman@gmail.com', " +
              "bank account number '4037997432954623', and date of birth '2020-02-02' in customers list")]
        public async Task Register_registers_a_customer_properly()
        {
            var dto = new RegisterCustomerDtoBuilder()
                .WithFirstName("Arman")
                .WithLastName("Ziaei")
                .WithEmail("arman@gmail.com")
                .WithBankAccountNumber("4037997432954623")
                .WithPhoneNumber("09397136812")
                .WithDateOfBirth(new DateTime(2020, 02, 02))
                .Build();

            var userId = await _sut.Register(dto);

            var actualResult = _readDataContext.Customers.Single(
                _ => _.Id == userId);
            actualResult.FirstName.Should().Be(dto.FirstName);
            actualResult.LastName.Should().Be(dto.LastName);
            actualResult.DateOfBirth.Should().Be(dto.DateOfBirth);
            actualResult.PhoneNumber.Should().Be(dto.PhoneNumber);
            actualResult.Email.Should().Be(dto.Email);
            actualResult.BankAccountNumber.Should().Be(dto.BankAccountNumber);
        }
    }
    
    
}