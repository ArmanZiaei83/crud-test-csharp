using System.ComponentModel.DataAnnotations;
using Mc2.CrudTest.Infrastructure.Shared.Validations.Attributes;

namespace Mc2.CrudTest.Application.DTOs.Customers;

public class UpdateCustomerDto
{
    [Required] [MaxLength(20)] public string FirstName { get; set; }

    [Required] [MaxLength(20)] public string LastName { get; set; }

    [Required] public DateTime DateOfBirth { get; set; }

    public string PhoneNumber { get; set; }

    [Required] [ValidateEmail] public string Email { get; set; }

    [Required]
    [ValidateBankAccountNumber]
    public string BankAccountNumber { get; set; }

    [Required] [MaxLength(5)] public string CountryCallingCode { get; set; }
}