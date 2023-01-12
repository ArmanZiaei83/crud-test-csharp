using System;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using FluentAssertions;
using Mc2.CrudTest.AcceptanceTests.Infrastructures;
using Mc2.CrudTest.AcceptanceTests.TestTools;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests : TestProvider
    {
        private readonly CustomerService _sut;

        public BddTddTests()
        {
            _sut = CustomerFactory.CreateService(_dataContext);
        }

        [Fact]
        public async Task CreateCustomerValid_ReturnsSuccess()
        {
            var dto = new RegisterCustomerDtoBuilder()
                .Build();

            var userId = await _sut.Register(dto);

            var actualResult = _readDataContext.Customers
                .Single(_ => _.Id == userId);
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
        [Then(
            "There must be a customer with first name 'arman', last name 'ziaei', " +
            "phone number '09397136812', email 'arman@gmail.com', " +
            "bank account number '4037997432954623', and date of birth '2020-02-02' in customers list")]
        public async Task Register_registers_a_customer_properly()
        {
            var dto = new RegisterCustomerDtoBuilder()
                .WithFirstName("Arman")
                .WithLastName("Ziaei")
                .WithEmail("arman@gmail.com")
                .WithBankAccountNumber("4037997432954623")
                .WithPhoneNumber("+989397136812")
                .WithCountryCallingCode("98")
                .WithDateOfBirth(new DateTime(2020, 02, 02))
                .Build();

            var userId = await _sut.Register(dto);

            var actualResult = _readDataContext.Customers
                .Single(_ => _.Id == userId);
            actualResult.FirstName.Should().Be(dto.FirstName);
            actualResult.LastName.Should().Be(dto.LastName);
            actualResult.DateOfBirth.Should().Be(dto.DateOfBirth);
            actualResult.PhoneNumber.Should().Be(dto.PhoneNumber);
            actualResult.Email.Should().Be(dto.Email);
            actualResult.BankAccountNumber.Should().Be(dto.BankAccountNumber);
        }

        [Theory]
        [InlineData("98", "+9893971368")]
        [InlineData("98", "+9890171")]
        public async Task
            Register_throws_InvalidPhoneNumberException_when_phone_number_is_invalid(
                string countryCallingCode, string invalidPhoneNumber)
        {
            var dto = new RegisterCustomerDtoBuilder()
                .WithCountryCallingCode(countryCallingCode)
                .WithPhoneNumber(invalidPhoneNumber)
                .Build();

            Func<Task> actualResult = () => _sut.Register(dto);

            await actualResult.Should()
                .ThrowExactlyAsync<InvalidPhoneNumberException>();
        }

        [Fact]
        public async Task Get_gets_customer_by_id_properly()
        {
            var customer = CustomerFactory.Create();
            Save(customer);

            var actualResult = await _sut.Get(customer.Id);

            actualResult.Id.Should().Be(customer.Id);
            actualResult.Email.Should().Be(customer.Email);
            actualResult.FirstName.Should().Be(customer.FirstName);
            actualResult.LastName.Should().Be(customer.LastName);
            actualResult.DateOfBirth.Should().Be(customer.DateOfBirth);
            actualResult.BankAccountNumber.Should()
                .Be(customer.BankAccountNumber);
            actualResult.PhoneNumber.Should().Be(customer.PhoneNumber);
        }

        [Fact]
        public async Task Update_updates_customer_properly()
        {
            var customer = CustomerFactory.Create();
            Save(customer);
            var dto = new UpdateCustomerDtoBuilder()
                .WithFirstName("Arman")
                .WithLastName("Ziaei")
                .WithEmail("arman@gmail.com")
                .WithBankAccountNumber("4037997432954623")
                .WithPhoneNumber("+989397136812")
                .WithCountryCallingCode("98")
                .WithDateOfBirth(new DateTime(2020, 02, 02))
                .Build();

            await _sut.Update(customer.Id, dto);

            var actualResult = _readDataContext.Customers
                .Single(_ => _.Id == customer.Id);
            actualResult.FirstName.Should().Be(dto.FirstName);
            actualResult.LastName.Should().Be(dto.LastName);
            actualResult.DateOfBirth.Should().Be(dto.DateOfBirth);
            actualResult.PhoneNumber.Should().Be(dto.PhoneNumber);
            actualResult.Email.Should().Be(dto.Email);
            actualResult.BankAccountNumber.Should().Be(dto.BankAccountNumber);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async Task
            Update_throws_CustomerNotFoundException_when_customer_id_is_invalid(
                int invalidCustomerId)
        {
            var dto = new UpdateCustomerDtoBuilder().Build();

            Func<Task> actualResult = () => _sut.Update(invalidCustomerId, dto);

            await actualResult.Should()
                .ThrowExactlyAsync<CustomerNotFoundException>();
        }

        [Fact]
        public async Task Delete_deletes_customer_properly()
        {
            var customer = CustomerFactory.Create();
            Save(customer);

            await _sut.Delete(customer.Id);

            _readDataContext.Customers.Should()
                .NotContain(_ => _.Id == customer.Id);
        }
    }
}