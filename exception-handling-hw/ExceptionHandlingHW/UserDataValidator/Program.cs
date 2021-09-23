using System;
using UserDataValidator.Contracts;
using UserDataValidator.Models;

namespace UserDataValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            UserData userdata = new();
            userdata.Read();

            IUserDataValidator dataValidator = new Models.UserDataValidator();

            if (dataValidator.IsValid(userdata))
                Console.WriteLine("Status: Success! The information seems valid.");
            else
                Console.WriteLine("Status: Failed. Invalid data detected.");
        }
    }
}
