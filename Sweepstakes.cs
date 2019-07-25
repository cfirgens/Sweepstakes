﻿using System;
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
            Winner winner = new Winner();
            int winnerKey;
            Contestant winnerContestant;
            Random random = new Random();
            index = random.Next(0, contestants.Count - 1);
            winnerContestant = contestants.ElementAt(index).Value;
            winnerKey = contestants.ElementAt(index).Key;


            TransferContestantToWinner(winner, winnerContestant, winnerKey);
            winner.Notify();
            NotifyContestants();
            //EmailWinner(winner);
            return winner.FirstName + " " + winner.LastName;
        }

        private void EmailWinner(Winner winner)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sweepstakes Manager", "Sweepstakes@sweep.com"));
            message.To.Add(new MailboxAddress(winner.FirstName + winner.LastName, winner.Email));
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

                client.Connect("smtp.friends.com", 587, false);

                client.Send(message);
                client.Disconnect(true);
            }
        }

        private void TransferContestantToWinner(Winner winner, Contestant winnerContestant, int winnerKey)
        {
            winner.FirstName = winnerContestant.FirstName;
            winner.LastName = winnerContestant.LastName;
            winner.Email = winnerContestant.Email;
            winner.RegistrationNumber = winnerContestant.RegistrationNumber;
            contestants.Remove(winnerKey);
        }
        private void NotifyContestants()
        {
            for(int index = 0; index < contestants.Count; index ++)
            {
                var contestant = contestants.ElementAt(index);
                contestant.Value.Notify();
            }
        }

    }
}