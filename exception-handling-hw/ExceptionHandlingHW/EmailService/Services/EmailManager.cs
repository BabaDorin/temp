using EmailService.Contracts;
using EmailService.Models;
using EmailService.Models.CustomExceptions;
using System;
using System.Collections.Generic;

namespace EmailService.Services
{
    /// <summary>
    /// Uses an EmailService instance to send emails and handles exceptions
    /// </summary>
    class EmailManager : IEmailManager
    {
        private IEmailService _emailService;
        private IEmailSplitter _emailSplitter;

        public EmailManager(IEmailService emailService, IEmailSplitter emailSplitter)
        {
            _emailService = emailService;
            _emailSplitter = emailSplitter;
        }

        public void SendEmail(EmailData emailData)
        {
            // It internally uses a queue of emails.
            Queue<EmailData> emailsToSend = new();
            emailsToSend.Enqueue(emailData);

            while (emailsToSend.Count > 0)
            {
                var curentEmail = emailsToSend.Dequeue();

                try
                {
                    _emailService.SendEmail(curentEmail);
                }
                catch (EmailContentOverflowException ex)
                {
                    // This happens when the email's content exceeds the maximum content length.
                    // In this case, the email is splitted into multiple smaller e-mails, which are enqueued
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("It will be splitted into multiple smaller emails...");
                    SplitAndEnqueue(emailsToSend, curentEmail);
                }
                catch (UnavailableEmailServiceException ex)
                {
                    // The service is unavailable. In this case, we ask the user for another attempt.
                    // If the user agrees, we put the email back into the queue.
                    Console.WriteLine(ex.Message);
                    Retry(emailsToSend, emailData);
                }
                catch (InvalidEmailAddress ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An unknown error occured. Please, try again. \nDetails: {e.Message}");
                }
            }
        }

        private void SplitAndEnqueue(Queue<EmailData> emailsToSend, EmailData emailData)
        {
            IEnumerable<EmailData> splittedEmails = _emailSplitter
                                    .SplitEmail(emailData, _emailService.MaxContentLength);

            foreach (var email in splittedEmails)
                emailsToSend.Enqueue(email);
        }

        private void Retry(Queue<EmailData> emailsToSend, EmailData emailData)
        {
            Console.Write("Try again? (Y/N): ");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                emailsToSend.Enqueue(emailData);
                Console.WriteLine("The email has been enqueued for an additional try.");
            }
        }

        public void ActivateEmailService()
        {
            _emailService.IsServiceAvailable = true;
        }

        public void DeactivateEmailService()
        {
            _emailService.IsServiceAvailable = false;
        }
    }
}
