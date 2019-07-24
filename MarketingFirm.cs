namespace Sweepstakes
{
    public class MarketingFirm
    {
        //member variables
        ISweepstakesManager manager;
        //constructor

        public MarketingFirm(ISweepstakesManager manager)
        {
            this.manager = manager;
        }
      
    }
}