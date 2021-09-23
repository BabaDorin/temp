using UserDataValidator.Models;

namespace UserDataValidator.Contracts
{
    /// <summary>
    /// Checks if an userData object is valid
    /// </summary>
    interface IUserDataValidator
    {
        public bool IsValid(UserData userdate);
    }
}
