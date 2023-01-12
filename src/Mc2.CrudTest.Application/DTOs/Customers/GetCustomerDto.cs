namespace Mc2.CrudTest.Application.DTOs.Customers;

public class GetCustomerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}