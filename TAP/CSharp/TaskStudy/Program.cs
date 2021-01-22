using System;
using System.Threading;
using System.Threading.Tasks;
using TaskStudy.CookBook;
using TaskStudy.CookBook.Chapter_2;

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
            
            #region Chapter 2
            //await Delay.CalcWithDelays();
            
            //await TimeOut.CalcUntilTimeout(TimeSpan.FromSeconds(4));
            //await TimeOut.CalcUntilTimeout(TimeSpan.FromSeconds(1));
            //TrySleep();

            // await CompletedTask.Get().CalcSomething();
            // await CompletedTask.Get().CalcSomething();
            // await CompletedTask.Get().CalcSomething();

            // var progress = new Progress<int>();
            // progress.ProgressChanged += (_, i) => Console.WriteLine("Task is on step" + i);
            // await CustomAwaiter.Progress(progress);

            // var ret = await SetOfTaskToComplete.BigSum();
            // Console.WriteLine($"Calculated {ret} from several tasks");

            var ret = await ProcessAsComplete.Calc();
            Console.WriteLine($"Calculated {ret} from several tasks running in sequence");
            #endregion
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