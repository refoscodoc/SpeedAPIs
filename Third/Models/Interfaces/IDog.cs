using System;

namespace Third.Models.Interfaces
{
    public interface IDog
    {
        void RollOver()
        {
            throw new InvalidOperationException();
        }
        
        void GivePaw()
        {
            throw new InvalidOperationException();
        }
    }
}