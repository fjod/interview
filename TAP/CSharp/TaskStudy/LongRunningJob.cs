
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TaskStudy
{
    public static class LongRunningJob
    { 
        public static long CalcSum(int retries = 10000)
        {
            var startTime = DateTime.Now;
            var range = Enumerable.Range(0, 65000);
            long sum = 0;
            for (int i = 0; i < retries; i++)
            {
                sum += range.Sum();
            }
            Console.WriteLine($"Calculated sum = {sum} for {retries} tries in  {(DateTime.Now - startTime).TotalMilliseconds} ms");
            return sum;
        }
    }
}