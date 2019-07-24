using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class MarketingFirm
    {
        //member variables
        ISweepstakesManager manager;
        List<Contestant> contestants = new List<Contestant>();
        Sweepstakes sweepstakes;

        //constructor

        public MarketingFirm(ISweepstakesManager manager)
        {
            this.manager = manager;
        }
        public void CreateSweepStakes()
        {
            string sweepstakesName;
            Console.WriteLine("What would you like to name the sweepstakes?");
            sweepstakesName = Console.ReadLine();

            this.sweepstakes = new Sweepstakes(sweepstakesName);
            manager.InsertSweepstakes(sweepstakes);
        }

        public void CreateContestant()
        {
            Contestant contestant = new Contestant();
            contestant.GetNewContestant();
            contestants.Add(contestant);
        }

        public void AddContestantsToSweepstakes()
        {
            for (int index = 0; index < contestants.Count; index++)
            {
                sweepstakes.RegisterContestant(contestants[index]);
            }
        }

    }
}