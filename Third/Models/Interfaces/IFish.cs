using System;

namespace Third.Models.Interfaces
{
    public interface IFish
    {
        void JumpOutsideBowl()
        {
            throw new InvalidOperationException();
        }
        
        void StayAlive()
        {
            throw new InvalidOperationException();
        }
    }
}