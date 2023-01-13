using System;
using Mc2.CrudTest.Application.DTOs.Customers;

namespace Mc2.CrudTest.AcceptanceTests.TestTools.Builders
{
    public class UpdateCustomerDtoBuilder
    {
        private readonly UpdateCustomerDto _dto;

        public UpdateCustomerDtoBuilder()
        {
            _dto = new UpdateCustomerDto
            {
                FirstName = "dummy-first-name",
                LastName = "dummy-last-name",
                DateOfBirth = new DateTime(2020, 2, 2),
                PhoneNumber = "+989397136812",
                Email = "dummy@gmail.com",
                BankAccountNumber = "12312312312323",
                CountryCallingCode = "98"
            };
        }

        public UpdateCustomerDtoBuilder WithFirstName(string firstName)
        {
            _dto.FirstName = firstName;
            return this;
        }

        public UpdateCustomerDtoBuilder WithLastName(string lastName)
        {
            _dto.LastName = lastName;
            return this;
        }

        public UpdateCustomerDtoBuilder WithEmail(string email)
        {
            _dto.Email = email;
            return this;
        }

        public UpdateCustomerDtoBuilder WithBankAccountNumber(
            string backAccountNumber)
        {
            _dto.BankAccountNumber = backAccountNumber;
            return this;
        }

        public UpdateCustomerDtoBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            _dto.DateOfBirth = dateOfBirth;
            return this;
        }

        public UpdateCustomerDtoBuilder WithPhoneNumber(string phoneNumber)
        {
            _dto.PhoneNumber = phoneNumber;
            return this;
        }

        public UpdateCustomerDtoBuilder WithCountryCallingCode(
            string countryCallingCode)
        {
            _dto.CountryCallingCode = countryCallingCode;
            return this;
        }

        public UpdateCustomerDto Build()
        {
            return _dto;
        }
    }
}