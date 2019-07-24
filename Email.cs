using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Sweepstakes
{
    class Email
    {
        public void EmailWinner(string firstName, string lastName, string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sweepstakes Manager", "Sweepstakes@sweep.com"));
            message.To.Add(new MailboxAddress(firstName + lastName, email));
            message.Subject = "Congratulations! You won the sweepstakes";

            message.Body = new TextPart("plain")
            {
                Text = @"Dear contestant,
                    You have won the sweepstakes, congratulations! Please contact the sweepstakes manager to claim your prize.
                    Sweepstakes manager can be reached at (414) 999-6666. Please have your name, email and registration number when you call

                    --Sweepstakes team"
            };

            using (var client = new SmtpClient())
            {
                //accepting all SSL certs
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
