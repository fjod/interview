﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TaskStudy.CookBook;
using TaskStudy.CookBook.Chapter_12;
using TaskStudy.CookBook.Chapter_2;
using TaskStudy.CookBook.Chapter_2.Value;
using TaskStudy.CookBook.Chapter_3;
using TaskStudy.CookBook.Chapter_4;
using TaskStudy.CookBook.Chapter_9;

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
             
             
             // AsyncCancellation cancellation = new AsyncCancellation();
             // using var token = new CancellationTokenSource();
             // var query = cancellation.CancelMe(token.Token);
             // var now = DateTime.Now;
             // await foreach (var i in query)
             // {
             //     Console.WriteLine($"Got {i} from yandex");
             //     var diff = (DateTime.Now - now).TotalSeconds;
             //     Console.WriteLine($"It took {diff} seconds total");
             //     if (diff > 10)
             //     {
             //         token.Cancel();
             //         break;
             //     }
             // }

             #endregion

             #region Chapter 4

             // ParallelBasics pb = new ParallelBasics();
             // List<BigClass> input = new List<BigClass>(); 
             // foreach (var i in Enumerable.Range(0,5))
             // {
             //    
             //     input.Add(new BigClass());
             // }
             // var ret = pb.CalcAsParallel3(input);
             // Console.WriteLine($"result of parallel calc is {ret}");

             // var t = new Invoke();
             // var ret = t.Test(new BigClass(), new BigClass());
             // Console.WriteLine($"result of parallel calc is {ret}");

             #endregion

             #region Chapter 9

             // var z = new Collections();
             // z.TestStack();

             #endregion

             #region Chapter 12

             // Modify m = new Modify();
             // var ret = await m.Check();
             // Console.WriteLine(ret);

             // AsyncSignal ass = new AsyncSignal();
             // var t1 = ass.Initialize();
             // var t2 = ass.WaitForInitAsync();
             // await Task.WhenAll(t1, t2);
             // Console.WriteLine(t2.Result);   
             #endregion

             #region Chapter 14

             int val = 0;
             Lazy<int> Shared = new Lazy<int>(() => val = 10);
             Console.WriteLine(Shared.Value);
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