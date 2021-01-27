using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_4
{
    public class Invoke
    {
        /// <summary>
        /// 4.3 Invoke in parallel by providing funcs to calc
        /// </summary>
        /// <param name="job1"></param>
        /// <param name="job2"></param>
        /// <returns></returns>
        public long Test(BigClass job1, BigClass job2)
        {
            long result = 0;
            object mutex = new object();
            
            void Result(object o,BigClass job)
            {
                job.PerformCalc();
                lock (o)
                {
                    result += job.Result;
                }
            }
            Parallel.Invoke(() => { Result(mutex,job1); }, (() => { Result(mutex,job2); }));
            return result;
        }
    }
}