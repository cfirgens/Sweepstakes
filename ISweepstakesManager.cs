namespace Sweepstakes
{
    interface ISweepstakesManager
    {
        Sweepstakes GetSweepstakes();

        void InsertSweepstakes(Sweepstakes sweepstakes);
        
       
    }
}