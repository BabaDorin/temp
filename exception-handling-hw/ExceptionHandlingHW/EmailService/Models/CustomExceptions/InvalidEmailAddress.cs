using System;

namespace EmailService.Models.CustomExceptions
{
    class InvalidEmailAddress : Exception
    {
        public InvalidEmailAddress(string message)
            : base(message)
        {

        }
    }
}
