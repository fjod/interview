using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TaskStudy.CookBook;
using TaskStudy.CookBook.Chapter_2;
using TaskStudy.CookBook.Chapter_2.Value;
using TaskStudy.CookBook.Chapter_3;

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

            // var ret = await ProcessAsComplete.Calc();
            // Console.WriteLine($"Calculated {ret} from several tasks running in sequence");
            
            // var ret1 = await Context.SwitchOnContext(); //thread 1 -> 4 -> 4 -> 5
            // var ret2 = await Context.SameContext();
            
             // Context.PrintThread("1");
             // var ret2 = await Context.SameContext();
             // Context.PrintThread("2");
             // var ret1 = await Context.SwitchOnContext();
             // Context.PrintThread("3");
          
             //await AsyncVoidWrap.Invoke();

             // try
             // {
             //     await CompletedValueTask.Get().CalcSomething();
             //     await CompletedValueTask.Get().CalcSomething();
             //     await CompletedValueTask.Get().CalcSomething();
             // }
             // catch (Exception e)
             // {
             //     Console.WriteLine(e);
             // }
             // ValueTaskConsumerImp r = new ValueTaskConsumerImp();
             // await r.Test();

             #endregion
             
             #region Chapter 3

             // AsyncEnumerable enumerable = new AsyncEnumerable();
             // var ret = enumerable.GetValues();
             // await foreach (var result in ret)
             // {
             //     Console.WriteLine(result);
             // }
             
             
             AsyncCancellation cancellation = new AsyncCancellation();
             using var token = new CancellationTokenSource();
             var query = cancellation.CancelMe(token.Token);
             var now = DateTime.Now;
             await foreach (var i in query)
             {
                 Console.WriteLine($"Got {i} from yandex");
                 var diff = (DateTime.Now - now).TotalSeconds;
                 Console.WriteLine($"It took {diff} seconds total");
                 if (diff > 10)
                 {
                     token.Cancel();
                     break;
                 }
             }

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