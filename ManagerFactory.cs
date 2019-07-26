using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class ManagerFactory
    {    
        public ISweepstakesManager GetSweepstakesManager()
        {
            Console.WriteLine("Which management style would you like to use? Stack or Queue");
            string manager = Console.ReadLine();
            switch (manager.ToLower())
            {
                case "stack":
                    return new SweepstakesStackManager();
                case "queue":
                    return new SweepstakesQueueManager();
                default:
                    Console.WriteLine("That was not a valid choice");
                    return GetSweepstakesManager();
            }
        }
    }
}
