using System;

namespace EmailService.Models.CustomExceptions
{
    class EmailContentOverflowException : Exception
    {
        public EmailContentOverflowException(string message)
            : base(message)
        {

        }
    }
}
