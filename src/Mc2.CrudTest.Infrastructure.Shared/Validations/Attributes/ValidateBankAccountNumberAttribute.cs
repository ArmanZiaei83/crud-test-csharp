using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Infrastructure.Shared.Validations.Attributes;

public class ValidateBankAccountNumberAttribute : ValidationAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return base.FormatErrorMessage("bank account number");
    }

    public override bool IsValid(object? bankAccountNumberValue)
    {
        var bankAccountNumber = bankAccountNumberValue.ToString();
        if (string.IsNullOrEmpty(bankAccountNumber)) return false;

        Regex regex = new("^[0-9]{9,18}$");

        return regex.IsMatch(bankAccountNumber);
    }
}