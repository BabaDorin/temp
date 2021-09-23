using System;
using UserDataValidator.Contracts;

namespace UserDataValidator.Models.UserPropertyValidators
{
    class DateOfBirthPropertyValidator : IUserPropertyValidator
    {
        public bool IsValid(UserData userData)
        {
            // The birthdate should not be in the future.

            if (userData.DateOfBirth <= DateTime.Now)
                return true;

            throw new InvalidUserDataException($"{userData.DateOfBirth} is not a valid date of birth.");
        }
    }
}
