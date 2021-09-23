using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UserDataValidator.Contracts;

namespace UserDataValidator.Models
{
    class UserDataValidator : IUserDataValidator
    {
        // The validation logic works this way:

        // In order to follow the Open-Closed principle, I've defined an interface - IUserPropertyValidator.
        // Each UserData property that has to be validated has it's own PropertyValidator - which implmenents the interface from above.
        // The main validator (this) uses reflection to create instances of types that implements IUserPropertyValidator
        // and then uses them one by one to check the validity of our userData object.

        // Now, if there will be additional properties added to UserData, all we have to do is to create another validator
        // via implementing IUserPropertyValidator without the need of modify any existing code.
        
        /// <summary>
        /// Checks the validity of an UserData instance
        /// </summary>
        /// <param name="userData"></param>
        /// <returns>
        /// True if all of the properties are valid.
        /// False if at least one property contains invalid data.
        /// </returns>
        public bool IsValid(UserData userData)
        {
            var propertyValidators = GetPropertyValidators();
            bool isValid = true;

            foreach (IUserPropertyValidator validator in propertyValidators)
            {
                try
                {
                    isValid = validator.IsValid(userData) & isValid;
                }
                catch (InvalidUserDataException ex)
                {
                    Console.WriteLine($"Invalid user data provided. Details: {ex.Message}");
                    isValid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unknown error occured. Details: {ex.Message}");
                    isValid = false;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Creates one instance per each type that implements IUserPropertyValidator
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IUserPropertyValidator> GetPropertyValidators()
        {
            var interf = typeof(IUserPropertyValidator);

            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(interf)
                         && !t.IsInterface);

            var instances = types.Select(t => (IUserPropertyValidator)Activator.CreateInstance(t))
                .ToList();

            return instances;
        }
    }
}
