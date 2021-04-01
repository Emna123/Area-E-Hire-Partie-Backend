using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService
{
  public interface IEmailSender
    {
        public  void SendEmail(Message message);

    }
}
