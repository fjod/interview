using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_2
{
    /// <summary>
    /// use Task.Delay when in need to wait for something; Chapter 2.1
    /// </summary>
    public static class Delay
    {
        public static async Task CalcWithDelays()
        {
            for (int i = 0; i < 3; i++)
            {
                var current = DateTime.Now;
                await CustomAwaiter.TryAwaitCustomType(CancellationToken.None);
                await Task.Delay(i*1500);    
                Console.WriteLine($"Total time was {(DateTime.Now -current).TotalMilliseconds} + with current delay {i*1500}");
            }
        }
    }

    /// <summary>
    /// wait for Task to finish with timeout
    /// </summary>
    public static class TimeOut
    {
        /// <summary>
        /// 2.5 WhenAny; note that when first task completes, others continue work
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public static async Task CalcUntilTimeout(TimeSpan span)
        {
            Console.WriteLine($"Starting with timeout span in seconds = {span.TotalSeconds}");
            using var cts = new CancellationTokenSource(span);
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            Task<long> work = CustomAwaiter.TryAwaitCustomType(cancelTokenSource.Token);
            Task timeout = Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);
            try
            {
                //both Tasks will work to completion until something cancels work!
                Task completedTask = await Task.WhenAny(timeout,work); 
                if (completedTask == timeout)
                {
                    cancelTokenSource.Cancel();
                    Console.WriteLine("Timeout task completed before calculations");
                }
                else
                {
                    Console.WriteLine($"Got {work.Result} from WhenAll Task");
                }
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("TaskCanceledException");
            }
         
           
        }
    }
}