using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    internal class Sweepstakes
    {
        //member variables
        List<Contestant> contestants = new List<Contestant>();
        string name;

        //constructor
        public Sweepstakes(string name)
        {
            this.name = name;
        }

        //methods
        public void RegisterContestant(Contestant contestant)
        {
            contestants.Add(contestant);
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            foreach (Contestant contestant in contestants)
            { 
                Console.WriteLine("Contestant name: " + contestant.FirstName + " " + contestant.LastName + " \nContestant email: " + contestant.Email + " \nContestant Registration Number: " + contestant.RegistrationNumber);
            }
        }
        
        public string PickWinner()
        {
            int index;
            Contestant winner;
            Random random = new Random();
            index = random.Next(1, contestants.Count - 1);
            winner = contestants[index];
            return winner.FirstName + " " + winner.LastName;
        }

    }
}