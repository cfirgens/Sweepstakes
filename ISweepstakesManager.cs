namespace Sweepstakes
{
    internal interface ISweepstakesManager
    {
        Sweepstakes GetSweepstakes();

        void InsertSweepstakes(Sweepstakes sweepstakes);
        
       
    }
}