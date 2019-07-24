using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Contestant
    {
        //member variables
        string firstName;
        string lastName;
        string email;
        int registrationNumber;

        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RegistrationNumber { get; set; }

        //constructor
        public Contestant(string firstName, string lastName, string email, int registrationNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.registrationNumber = registrationNumber;
        }

        //methods

        public void GetNewContestant()
        {
            Console.WriteLine("What is the contestants first name?");
            FirstName = Console.ReadLine();
            Console.WriteLine("What is the contestants last name?");
            LastName = Console.ReadLine();
            Console.WriteLine("What is the contestants email address?");
            Email = Console.ReadLine();
            RegistrationNumber = GetRegistrationNumber();
        }

        private int GetRegistrationNumber()
        {
            Random random = new Random();
            return random.Next(1, 1000);

        }
    }
}

