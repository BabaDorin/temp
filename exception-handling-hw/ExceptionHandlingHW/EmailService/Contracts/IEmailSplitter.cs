using EmailService.Models;
using System.Collections.Generic;

namespace EmailService.Contracts
{
    interface IEmailSplitter
    {
        IEnumerable<EmailData> SplitEmail(EmailData emailData, int maxContentLength);
    }
}