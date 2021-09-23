using EmailService.Models;

namespace EmailService.Contracts
{
    interface IEmailManager
    {
        void SendEmail(EmailData emailData);

        void ActivateEmailService();
        void DeactivateEmailService();
    }
}