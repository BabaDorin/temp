using System;
using UserDataValidator.Contracts;

namespace UserDataValidator.Models.UserPropertyValidators
{
    class EmailPropertyValidator : IUserPropertyValidator
    {
        public bool IsValid(UserData userData)
        {
            // something@something.com

            if (RegexHelper.IsRegexMatch(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", userData.Email))
                return true;

            throw new InvalidUserDataException($"{userData.Email} is not a valid email address.");
        }
    }
}
