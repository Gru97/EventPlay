using System;
using System.Collections.Generic;
using System.Text;
using EventPlay.variants.ObserverPattern;

namespace EventPlay.variants.CSharpEvents
{
   
    public class CounterCSharpEvents: ICounter
    {
        public event EventHandler<int> CounterChanged;
        private int number = 0;
        public void CountOne()
        {
            number++;
            CounterChanged?.Invoke(this, number);
        }

        public void StopCounter()
        {
            number = 0;
        }
    }

    public class Printer
    {
        public void Print()
        {
            CounterCSharpEvents counterObserverPattern = new CounterCSharpEvents();
            counterObserverPattern.CounterChanged += OnCounterChanged;
            //counterObserverPattern.CounterChanged += (object sender, int e) =>Console.WriteLine(e);

            for (int i = 0; i < 10; i++)
            {
                counterObserverPattern.CountOne();
            }

        }
        private void OnCounterChanged(object sender, int e)
        {
            Console.WriteLine(e);
        }
    }

    public class DriverForCounterCSharpEvents : IDriver
    {
        public void StartCounting()
        {
            Printer p=new Printer();
            p.Print();
        }
    }
}
