
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStudy
{
    public static class LongRunningJob
    {
        public static long CalcSum(int retries = 10000, CancellationToken token = default)
        {
            var startTime = DateTime.Now;
            var range = Enumerable.Range(0, 65000);
            long sum = 0;
            for (int i = 0; i < retries; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation requested!");
                    return sum;
                }
                sum += range.Sum();
            }
            Console.WriteLine($"Calculated sum = {sum} for {retries} tries in  {(DateTime.Now - startTime).TotalMilliseconds} ms");
            return sum;
        }
    }
}