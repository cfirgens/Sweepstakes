using System;
namespace Sweepstakes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ManagerFactory managerFactory = new ManagerFactory();

            var manager = managerFactory.GetSweepstakesManager();

            MarketingFirm marketingFirm = new MarketingFirm(manager);

            marketingFirm.CreateSweepStakes();


            marketingFirm.CreateContestant();
            marketingFirm.CreateContestant();
            marketingFirm.CreateContestant();
            marketingFirm.AddContestantsToSweepstakes();
                        
            string winnerName;
            winnerName = marketingFirm.sweepstakes.PickWinner();
            Console.WriteLine(winnerName);
            Console.ReadLine();


        }


    }
}