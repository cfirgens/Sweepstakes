using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        Queue<Sweepstakes> QueueSweepStakes = new Queue<Sweepstakes>();

        public Sweepstakes GetSweepstakes()
        {
            return QueueSweepStakes.Dequeue();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            QueueSweepStakes.Enqueue(sweepstakes);
        }

    }
}