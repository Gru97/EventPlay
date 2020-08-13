using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventPlay.variants.ObserverPattern
{
    public class CounterObserverPattern : IObservable<int>
    {
        private int number = 0;
        private List<IObserver<int>> observers;

        public CounterObserverPattern()
        {
            observers=new List<IObserver<int>>();
        }
        public void CountOne()
        {
            number++;

            foreach (var observer in observers)
            {
                observer.OnNext(number);
            }
        }

        public void StopCounter()
        {
            number = 0;
            foreach (var observer in observers)
            {
                observer.OnCompleted();
            }
            observers.Clear();
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                observer.OnNext(number);
            }


            //TODO: No idea what it means
            return default;
        }
    }

    public  class Printer:IObserver<int>
    {
        public void OnCompleted()
        {
            Console.WriteLine("observing counter completed");

        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.Data);

        }

        public void OnNext(int value)
        {
            Console.WriteLine(value);
        }
    }

    public class DriverForCounterObserverPattern: IDriver
    {
        public  void StartCounting()
        {
           var counter=new CounterObserverPattern();

            Printer printer=new Printer();

            counter.Subscribe(printer);

            for (int i = 0; i < 10; i++)
            {
                counter.CountOne();
            }
        }
    }
}
