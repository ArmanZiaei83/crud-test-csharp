using System.Runtime.CompilerServices;
using PhoneNumbers;

namespace Mc2.CrudTest.Infrastructure.Shared.Validations
{
    public static class PhoneNumberValidator
    {
        public static bool IsValid(string mobileNumber, string countryCode)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber parsedMobileNumber;

            try
            {
                parsedMobileNumber = phoneUtil.Parse(mobileNumber, countryCode);
            }
            catch (Exception e)
            {
                throw;
            }

            return phoneUtil.IsValidNumber(parsedMobileNumber);
        }
    }
}