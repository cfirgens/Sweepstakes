using System;

namespace Sweepstakes
{
    public class Contestant : IContestants
    {
        //member variables
        private string firstName;
        private string lastName;
        private string email;
        private int registrationNumber;

        //properties
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public int RegistrationNumber { get; set; }

        //constructor
        public Contestant()
        {
        }

        //methods

        public void GetNewContestant()
        {
            Console.WriteLine("What is the contestants first name?");
            firstName = Console.ReadLine();
            Console.WriteLine("What is the contestants last name?");
            lastName = Console.ReadLine();
            Console.WriteLine("What is the contestants email address?");
            email = Console.ReadLine();
            registrationNumber = GetRegistrationNumber();
        }

        private int GetRegistrationNumber()
        {
            Random random = new Random();
            return random.Next(1, 10000);
        }
        public void Notify()
        {
            Console.WriteLine(FirstName + ", sorry you did not win the sweepstakes, better luck next time!");
        }
    }
}