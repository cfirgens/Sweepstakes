using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class SweepstakesStackManager : ISweepstakesManager
    {
        Stack<Sweepstakes> stackSweepStacks = new Stack<Sweepstakes>();

        public Sweepstakes GetSweepstakes()
        {
            return stackSweepStacks.Pop();
           
        }
        
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {            
            stackSweepStacks.Push(sweepstakes);
        }
    }
}