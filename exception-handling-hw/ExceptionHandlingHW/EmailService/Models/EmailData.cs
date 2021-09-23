using System;

namespace EmailService.Models
{
    class EmailData : ICloneable
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public object Clone()
        {
            return new EmailData()
            {
                From = this.From,
                To = this.To,
                Subject = this.Subject,
                Content = this.Content
            };
        }

        public override string ToString()
        {
            string shortenContent = Content.Length > 25
                ? $"{Content.Substring(0, 25)}..."
                : Content;

            return $"From:\t\t{From}\n" +
                $"To:\t\t{To}\n" +
                $"Subject:\t{Subject}\n" +
                $"Content:\t{shortenContent}";
        }
    }
}
