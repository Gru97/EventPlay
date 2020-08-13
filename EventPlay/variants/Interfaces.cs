using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlay.variants
{
    public interface ICounter
    {
        void CountOne();
        void StopCounter();
    }

    public interface IDriver
    {
        void StartCounting();
    }
  
}
