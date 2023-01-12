using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Application.DTOs.Customers
{
    public class AddStudentDto
    {
        [Required] 
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string NationalCode { get; set; }
    }
}