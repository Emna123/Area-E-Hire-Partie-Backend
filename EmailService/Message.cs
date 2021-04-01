using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Logo { get; set; }
        public string Content { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public Message(IEnumerable<string> to, string subject, string logo, string content,string code,string url)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;
            Logo = logo;
            Code = code;
            Url = url;
        }
    }
}
