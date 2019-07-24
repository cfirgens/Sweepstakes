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
    public class Sweepstakes
    {
        //member variables
        Dictionary<int, Contestant> contestants = new Dictionary<int, Contestant>();
        string name;
        Contestant winner;

        //constructor
        public Sweepstakes(string name)
        {
            this.name = name;
        }

        //methods
        public void RegisterContestant(Contestant contestant)
        {
            contestants.Add(contestant.RegistrationNumber, contestant);
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine("Contestant name: " + contestant.FirstName + " " + contestant.LastName + " \nContestant email: " + contestant.Email + " \nContestant Registration Number: " + contestant.RegistrationNumber);
            
        }
        
        public string PickWinner()
        {
            int index;            
            Random random = new Random();
            index = random.Next(0, contestants.Count - 1);
            winner = contestants.ElementAt(index).Value;
            EmailWinner(winner);
            return winner.FirstName + " " + winner.LastName;
        }

        private void EmailWinner(Contestant contestant)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sweepstakes Manager", "Sweepstakes@sweep.com"));
            message.To.Add(new MailboxAddress(contestant.FirstName + contestant.LastName, contestant.Email));
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