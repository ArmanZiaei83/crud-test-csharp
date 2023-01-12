using System;
using Mc2.CrudTest.Application.DTOs.Customers;

namespace Mc2.CrudTest.AcceptanceTests.TestTools
{
    public class RegisterCustomerDtoBuilder
    {
        private RegisterCustomerDto _dto;

        public RegisterCustomerDtoBuilder()
        {
            _dto = new RegisterCustomerDto
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

        public RegisterCustomerDtoBuilder WithFirstName(string firstName)
        {
            _dto.FirstName = firstName;
            return this;
        }

        public RegisterCustomerDtoBuilder WithLastName(string lastName)
        {
            _dto.LastName = lastName;
            return this;
        }
        
        public RegisterCustomerDtoBuilder WithEmail(string email)
        {
            _dto.Email = email;
            return this;
        }
        public RegisterCustomerDtoBuilder WithBankAccountNumber(string backAccountNumber)
        {
            _dto.BankAccountNumber = backAccountNumber;
            return this;
        }

        public RegisterCustomerDtoBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            _dto.DateOfBirth = dateOfBirth;
            return this;
        }

        public RegisterCustomerDtoBuilder WithPhoneNumber(string phoneNumber)
        {
            _dto.PhoneNumber = phoneNumber;
            return this;
        }

        public RegisterCustomerDtoBuilder WithCountryCallingCode(string countryCallingCode)
        {
            _dto.CountryCallingCode = countryCallingCode;
            return this;
        }

        public RegisterCustomerDto Build()
        {
            return _dto;
        }
    }
}