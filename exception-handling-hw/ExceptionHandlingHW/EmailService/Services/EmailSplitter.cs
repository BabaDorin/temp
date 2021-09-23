using EmailService.Contracts;
using EmailService.Models;
using System.Collections.Generic;

namespace EmailService.Services
{
    class EmailSplitter : IEmailSplitter
    {
        public IEnumerable<EmailData> SplitEmail(EmailData emailData, int maxContentLength)
        {
            List<EmailData> splittedEmails = new List<EmailData>();

            if (emailData.Content.Length <= maxContentLength)
            {
                splittedEmails.Add(emailData);
                return splittedEmails;
            }

            // Basically we're splitting the email data into multiple email datas, having maximum
            // [maxContentLength] characters.
            int emailOrderNr = 1;
            for (int i = 0; i < emailData.Content.Length + maxContentLength; i += maxContentLength)
            {
                // say maxContentLength is 5, and we have this string:
                // abcdefg

                // first iteration:
                // abcdefg
                // ^i  ^lastCh
                // the first emailData will be composed out of 'abcde'

                // 2nd iteration
                // abcdefghi
                //      ^i ^lastCh
                // 2nd emailData - fghi

                // 3rd iteration
                // abcdefghi
                //         ^i
                //         ^lastCh
                // i overlaps with lastCh => we break the for loop

                int lastChIndex = i + maxContentLength;
                if (lastChIndex >= emailData.Content.Length)
                    lastChIndex = emailData.Content.Length;

                if (i >= emailData.Content.Length)
                    i = emailData.Content.Length - 1;

                if (i == lastChIndex - 1)
                    break;

                var splittedEmail = (EmailData)emailData.Clone();
                splittedEmail.Content = emailData.Content.Substring(i, lastChIndex - i);
                splittedEmail.Subject += $" ({emailOrderNr++})";
                splittedEmails.Add(splittedEmail);
            }

            return splittedEmails;
        }
    }
}
