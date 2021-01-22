using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStudy
{
    public static class LongRunningJob
    {

        public static Task<long> CalcSumTask(CancellationToken token = default)
        {
            var ret = CalcSum(token);
            return Task.FromResult(ret);
        }

        public static long CalcSum(CancellationToken token)
        {
            return CalcSum(10000, token);
        }

        public static long CalcSum()
        {
            return CalcSum(10000, new CancellationToken());
        }
        public static long CalcSum(int retries)
        {
            return CalcSum(retries, new CancellationToken());
        }
        public static long CalcSum(int retries, CancellationToken token)
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