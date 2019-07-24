namespace Sweepstakes
{
    public interface ISweepstakesManager
    {
        Sweepstakes GetSweepstakes();

        void InsertSweepstakes(Sweepstakes sweepstakes);
        
       
    }
}