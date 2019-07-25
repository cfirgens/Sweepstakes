using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Winner : IContestants
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
        public Winner()
        {
        }

        //methods

        private int GetRegistrationNumber()
        {
            Random random = new Random();
            return random.Next(1, 10000);
        }

        public void Notify()
        {
            Console.WriteLine(FirstName+ ", congratulations you are the winner");
        }
    }
}
