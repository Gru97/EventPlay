using System;
using System.Collections.Generic;
using System.Text;

namespace EventPlay.variants.PubSub
{
    public class CounterPubSubPattern:ICounter
    {
        private int number;
        private EventBus eventBus;

        public CounterPubSubPattern(EventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public void CountOne()
        {
            number++;
            eventBus.Publish(number);

        }

        public void StopCounter()
        {
            number = 0;
        }
    }

    public class Printer
    {
        private EventBus eventBus;

        public Printer(EventBus eventBus)
        {
            this.eventBus = eventBus;
            eventBus.Subscribe((int value)=>Console.WriteLine(value));
        }
    }


    public class EventBus
    {
        public delegate void CounterChanged(int value);
        private List<CounterChanged> handlers;

        public EventBus()
        {
            handlers=new List<CounterChanged>();
        }
        public void Publish(int value)
        {
            handlers.ForEach(e=>e.Invoke(value));
        }

        public void Subscribe(CounterChanged counterChangedDelegateInstance)
        {
            handlers.Add(counterChangedDelegateInstance);
        }
    }

    public class DriverForCounterPubSubPattern : IDriver
    {
        public void StartCounting()
        {
            var eventBus=new EventBus();
            Printer p=new Printer(eventBus);
            var counter = new CounterPubSubPattern(eventBus);
            for (int i = 0; i < 10; i++)
            {
                counter.CountOne();
            }
        }
    }
}
