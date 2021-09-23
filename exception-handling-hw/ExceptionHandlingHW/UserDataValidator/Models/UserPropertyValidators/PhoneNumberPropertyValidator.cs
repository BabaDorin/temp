using UserDataValidator.Contracts;

namespace UserDataValidator.Models.UserPropertyValidators
{
    class PhoneNumberPropertyValidator : IUserPropertyValidator
    {
        public bool IsValid(UserData userData)
        {
            // minimum 4, maximum 20 characters (digits and '+', '(', ')', ' ')

            if (RegexHelper.IsRegexMatch(@"^[0-9+() ]{4,20}$", userData.PhoneNumber))
                return true;

            throw new InvalidUserDataException($"{userData.PhoneNumber} is not a valid phone number");
        }
    }
}
