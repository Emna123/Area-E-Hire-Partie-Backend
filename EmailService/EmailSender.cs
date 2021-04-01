using MailKit.Net.Smtp;
using MimeKit;
using System;

using System.Text;

namespace EmailService
{
  public  class EmailSender: IEmailSender
    {
        public readonly EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
        public MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
          
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new  TextPart(MimeKit.Text.TextFormat.Html) { Text =string.Format("<br/><br/><img src='{0}' style='height: 100px;width: 150px;margin-left: 200px;'/><hr style='color:#9B59B6;width: 500px;margin-left: 200px;'><br/>", message.Logo) + string.Format("<p style='margin-left: 200px;font-size: 15px;'>Bonjour,<br/>{0}</p>", message.Content)+ string.Format("<div style='margin-left: 200px;font-size: 20px;background-color:#F5EEF8;border: 1px solid #20243E;padding:5px;border-radius: 10px;width: 60px;'>{0}</div><p style='margin-left: 200px;font-size: 15px; color:#000000;'>Vous pouvez aussi changer directement votre mot de passe.</p></br><a href={1}><button  style='background-color:#20243E;color:#FEFEFE ;margin-left: 300px;border: 1px solid #20243E;padding:20px;font-size: 15px;border-radius: 10px;'>Changer votre mot de passe</button></a></ p>", message.Code, message.Url) };
            return emailMessage;
        }
        public void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
