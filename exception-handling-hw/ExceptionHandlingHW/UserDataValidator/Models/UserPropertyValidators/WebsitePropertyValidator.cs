using UserDataValidator.Contracts;

namespace UserDataValidator.Models.UserPropertyValidators
{
    class WebsitePropertyValidator : IUserPropertyValidator
    {
        public bool IsValid(UserData userData)
        {
            // ex: something.com

            if (RegexHelper.IsRegexMatch(
                @"[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)",
                userData.Website))
                return true;

            throw new InvalidUserDataException($"{userData.Website} is not a valid website.");
        }
    }
}
