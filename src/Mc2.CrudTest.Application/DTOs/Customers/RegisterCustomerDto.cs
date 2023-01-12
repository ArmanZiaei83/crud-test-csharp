using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Application.DTOs.Customers
{
    public class RegisterCustomerDto
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string BankAccountNumber { get; set; }
    }
}