using EmailService.Contracts;
using EmailService.Models;
using EmailService.Services;
using System;
using System.Collections.Generic;

namespace EmailService
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmailManager emailManager = new EmailManager(
                new Services.EmailService(),
                new EmailSplitter());

            EmailData emailData = new EmailData()
            {
                From = "Dorin.Baba@endava.com",
                To = "Maks.Korj@gmail.com",
                Subject = "Hi",
                Content = "12345"
            };

            // First of all, a positive test case
            DisplayTestHeader("Test case: Email has to be delivered without any problem");
            emailManager.SendEmail(emailData);
            Console.WriteLine("\n------------------------------------------");

            // For easier testing, maximum content length for an email has been set to 10 characters.
            // Our email's content has 38 characters.
            // It will be splitted into 4 separate mails of length 10, 10, 10 and 8.
            DisplayTestHeader("Test case: Email content too large - split it");
            emailData.Content = "1.2.3.4.5.6.7.8.9.10.11.12.13.14.15.16"; // <= 38 characters
            emailManager.SendEmail(emailData);
            Console.WriteLine("\n------------------------------------------");

            // EmailService also runs a validity check agains From and To addresses
            DisplayTestHeader("Test case: Invalid recipient email address\n");
            emailData.To = "invalidAddress";
            emailManager.SendEmail(emailData);
            Console.WriteLine("\n------------------------------------------");

            // We can deactivete the email service.
            // In this case, the user will be asked if he wants to retry the attempt
            // due to email service being unavailable at the moment
            DisplayTestHeader("Test case: Email service unavailable\n");
            emailManager.DeactivateEmailService();
            emailManager.SendEmail(emailData);
            emailManager.ActivateEmailService();
            Console.WriteLine("\n------------------------------------------");
        }

        private static void DisplayTestHeader(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}