using System;
using System.Threading;
using System.Threading.Tasks;
using TaskStudy.CookBook;

namespace TaskStudy
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // LongRunningJob.CalcSum(); //just to try if it's really long running one!
            //await CustomAwaiter.TryAwaitCustomType(); //remember, it blocks the current Thread!
            //await CustomAwaiter.TryTCSAwaiter(); //also blocks Thread
            
            //cookBook
            //await Delay.CalcWithDelays();
            await TimeOut.CalcUntilTimeout(TimeSpan.FromSeconds(4));
            await TimeOut.CalcUntilTimeout(TimeSpan.FromSeconds(1));
            TrySleep();
        }

        private static void TrySleep()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
        }
    }
}