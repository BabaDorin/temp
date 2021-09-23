using System;

namespace EmailService.Models.CustomExceptions
{
    class UnavailableEmailServiceException : Exception
    {
        public UnavailableEmailServiceException(string message)
            : base(message)
        {

        }
    }
}
