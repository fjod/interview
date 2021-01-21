using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStudy.CookBook
{
    /// <summary>
    /// use Task.Delay when in need to wait for something
    /// </summary>
    public static class Delay
    {
        public static async Task CalcWithDelays()
        {
            for (int i = 0; i < 3; i++)
            {
                var current = DateTime.Now;
                await CustomAwaiter.TryAwaitCustomType();
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
        public static async Task CalcUntilTimeout(TimeSpan span)
        {
            Console.WriteLine($"Starting with timeout span in seconds = {span.TotalSeconds}");
            using var cts = new CancellationTokenSource(span);
            Task<long> work = CustomAwaiter.TryAwaitCustomType();
            Task timeout = Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);
            try
            {
                Task completedTask = await Task.WhenAny(timeout,work);
                if (completedTask == timeout)
                {
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