using EmailService.Contracts;
using EmailService.Models;
using EmailService.Models.CustomExceptions;
using System;
using System.Text.RegularExpressions;

namespace EmailService.Services
{
    /// <summary>
    /// Contains the logic of validating & sending the email
    /// </summary>
    class EmailService : IEmailService
    {
        public bool IsServiceAvailable { get; set; } = true; // Available by default
        public int MaxContentLength { get; set; } = 10; // for testing purposes

        public void SendEmail(EmailData emailData)
        {
            Console.WriteLine("\nThe email to be sent: ");
            Console.WriteLine(emailData + "\n");

            if (!IsServiceAvailable)
                throw new UnavailableEmailServiceException($"The email service is currently unavailable.");

            if (!IsValidEmailAddress(emailData.From))
                throw new InvalidEmailAddress($"{emailData.From} is not a valid email address.");

            if (!IsValidEmailAddress(emailData.To))
                throw new InvalidEmailAddress($"{emailData.To} is not a valid email address.");

            if (emailData.Content.Length > MaxContentLength)
                throw new EmailContentOverflowException($"Email's content exceeds maximum content legth of: {MaxContentLength} characters");

            // Send email logic...
            
            Console.WriteLine($"The email has been delivered!");
        }

        private bool IsValidEmailAddress(string emailAddress)
        {
            return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .IsMatch(emailAddress);
        }
    }
}
