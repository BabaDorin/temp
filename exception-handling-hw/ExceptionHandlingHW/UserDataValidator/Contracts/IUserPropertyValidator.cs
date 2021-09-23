using UserDataValidator.Models;

namespace UserDataValidator.Contracts
{
    /// <summary>
    /// Validates a specific property of UserData
    /// </summary>
    interface IUserPropertyValidator
    {
        public bool IsValid(UserData userData);
    }
}
