using System;

namespace Third.Models.Interfaces
{
    public interface IBird
    {
        void TellJoke()
        {
            throw new InvalidOperationException();
        }
        
        void GetTwoBeans()
        {
            throw new InvalidOperationException();
        }
    }
}