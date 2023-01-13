using PhoneNumbers;

namespace Mc2.CrudTest.Infrastructure.Shared.Validations;

public static class PhoneNumberValidator
{
    public static bool IsValid(string mobileNumber, string countryCode)
    {
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
        PhoneNumber parsedMobileNumber;

        parsedMobileNumber = phoneUtil.Parse(mobileNumber, countryCode);

        return phoneUtil.IsValidNumber(parsedMobileNumber);
    }
}