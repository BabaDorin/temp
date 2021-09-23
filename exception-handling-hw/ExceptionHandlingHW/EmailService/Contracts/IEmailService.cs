using EmailService.Models;

namespace EmailService.Contracts
{
    interface IEmailService
    {
        bool IsServiceAvailable { get; set; }
        int MaxContentLength { get; set; }

        void SendEmail(EmailData emailData);
    }
}