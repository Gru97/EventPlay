using System;
using System.IO;
using EventPlay.variants.CSharpEvents;
using EventPlay.variants.ObserverPattern;
using EventPlay.variants.PubSub;

namespace EventPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DriverForCounterObserverPattern\n");
            var driver1 = new DriverForCounterObserverPattern();
            driver1.StartCounting();
            Console.WriteLine("End. Press Enter.");
            Console.ReadLine();

            Console.WriteLine("DriverForCounterCSharpEvents\n");
            var driver2 = new DriverForCounterCSharpEvents();
            driver2.StartCounting();
            Console.WriteLine("End. Press Enter.");
            Console.ReadLine();

            Console.WriteLine("DriverForCounterPubSubPattern\n");
            var driver3 = new DriverForCounterPubSubPattern();
            driver3.StartCounting();
            Console.WriteLine("End. Press Enter.");
            Console.ReadLine();
            
        }
    }
}
