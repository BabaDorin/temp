using UserDataValidator.Contracts;

namespace UserDataValidator.Models.UserPropertyValidators
{
    class ZipCodePropertyValidator : IUserPropertyValidator
    {
        public bool IsValid(UserData userData)
        {
            // 4 digit code

            if (RegexHelper.IsRegexMatch(@"[0-9]{4}", userData.ZIPCode))
                return true;

            throw new InvalidUserDataException($"{userData.ZIPCode} is not a valid zip code.");
        }
    }
}
